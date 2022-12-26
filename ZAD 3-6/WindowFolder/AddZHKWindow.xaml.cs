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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZAD_3_6.ClassFolder;

namespace ZAD_3_6.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddZHKWindow.xaml
    /// </summary>
    public partial class AddZHKWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(
    @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=""ZAD 3"";Integrated Security=True");
        SqlCommand sqlCommand;
        public AddZHKWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(
                        "Insert Into dbo.Build (Name, Status, Count, Towns) " +
                    $"Values ('{NameTB.Text}', '{StatusTB.Text}', '{CountTB.Text}', '{TownTB.Text}')",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MbClass.InfoMB("ЖК добавлено");
                    
                }
                catch (Exception ex)
                {
                    MbClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new BuildList().Show();
            Close();
        }
    }
    }
