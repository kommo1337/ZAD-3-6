using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZAD_3_6.ClassFolder
{
    internal class DGClass
    {
        SqlConnection sqlConnection = new SqlConnection(
        @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=""ZAD 3"";Integrated Security=True");
        DataGrid dataGrid;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        public DGClass(DataGrid grid)
        {
            dataGrid = grid;
        }
        public void LoadDG(string command)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(command, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
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
        public string SelectId()
        {
            object[] mass = null;
            string id = "";
            try
            {
                if (dataGrid != null)
                {
                    DataRowView dataRowView = dataGrid.SelectedItem as DataRowView;
                    if (dataRowView != null)
                    {
                        DataRow dataRow = (DataRow)dataRowView.Row;
                        mass = dataRow.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch (Exception ex)
            {

            }
            return id;
        }

    }
}
