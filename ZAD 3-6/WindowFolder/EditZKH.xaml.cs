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
    /// Логика взаимодействия для EditZKH.xaml
    /// </summary>
    public partial class EditZKH : Window
    {
        SqlConnection sqlConnection = new SqlConnection(
        @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=""ZAD 3"";Integrated Security=True");
        SqlCommand sqlCommand;
        public EditZKH()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[Build] " +
                    $"Set Name ='{NameTB.Text}'," +
                    $"Status='{StatusTB.Text}'," +
                    $"Count=' {CountTB.Text}', " +
                    $"Towns='{TownTB.Text}' " +
                    $"Where Id='{VariableClass.BuildId}'",
                    sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MbClass.InfoMB($"Отредактирован");
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
    }
}
