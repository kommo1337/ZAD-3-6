using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZAD_3_6.ClassFolder;

namespace ZAD_3_6.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для BuildList.xaml
    /// </summary>
    public partial class BuildList : Window
    {
        SqlConnection sqlConnection = new SqlConnection(
        @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=""ZAD 3"";Integrated Security=True");
        SqlDataReader dataReader;
        SqlCommand command;
        DGClass dGClass;
        CBClass cBClass;
        public BuildList()
        {
            InitializeComponent();
            dGClass = new DGClass(BuildBookDG);
            cBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * From dbo.Build");
            cBClass.LoadStatus(StatusCB);
            cBClass.LoadTown(TownCB);
        }

        private void StatusCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * From dbo.Build " +
                $"Where Status Like '%{StatusCB.SelectedItem.ToString()}%'");
        }

        private void TownCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * From dbo.Build " +
                   $"Where Towns Like '%{TownCB.SelectedItem.ToString()}%'");
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            new AddZHKWindow().Show();
            Close();
        }

        private void BuildBookDG_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("delete", "вы хотете удалиьт", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                try
                {
                    sqlConnection.Open();
                    command = new SqlCommand($"DELETE FROM dbo.Build Where Id='{dGClass.SelectId()}'", sqlConnection);
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally { sqlConnection.Close(); }
            }
        }

        private void BuildBookDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuildBookDG.SelectedItem == null)
            {
                MbClass.ErrorMB("Выбирите строчку");
            }
            else
            {
                try
                {
                    VariableClass.BuildId = dGClass.SelectId();
                    new EditZKH().Show();
                    Close();
                }
                catch (Exception ex)
                {

                    MbClass.ErrorMB(ex);
                }
            }
        }
    }
}
