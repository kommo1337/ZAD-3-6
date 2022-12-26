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
    /// Логика взаимодействия для AutorisationWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(
    @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=""ZAD 3"";Integrated Security=True");
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        public AutorisationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MbClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MbClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(
                        "SELECT * From dbo.[User] " +
                        $"Where Login='{LoginTB.Text}'",
                        sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    if (PasswordPB.Password != dataReader[2].ToString())
                    {
                        MbClass.ErrorMB("Пароль не совпадает");
                    }
                    else
                    {
                        new BuildList().Show();
                        Close(); 
                    }
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
}
