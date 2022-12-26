using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZAD_3_6.ClassFolder
{

    internal class CBClass
    {
        SqlConnection sqlConnection = new SqlConnection(
        @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=""ZAD 3"";Integrated Security=True");
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void LoadStatus(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(
                    "Select * From dbo.Build " +
                    "Order by Id ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox.Items.Add(dataReader[2].ToString() );
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
        public void LoadTown(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(
                    "Select * From dbo.Build " +
                    "Order by Id ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox.Items.Add(dataReader[4].ToString());
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
