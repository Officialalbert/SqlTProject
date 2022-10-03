using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace SqlTProject
{
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("iyi");
            }

            DataGridLoad();
        }

        private void DataGridLoad()
        {
            //SqlDataReader dataReader = null;

            //try
            //{
            //    SqlCommand sql = new SqlCommand("Select product, category FROM Table", sqlConnection);
            //    dataReader = sql.ExecuteReader();
            //    ListViewItem item = null;
            //    while (dataReader.Read())
            //    {
            //        item = new ListViewItem();
            //        var it = new string[] { };
            //        LV_sql.Items.Add(item);
            //        item = new ListViewItem(it);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    if (dataReader != null && !dataReader.IsClosed)
            //    {
            //        dataReader.Close();
            //    }
            //}

            SqlDataAdapter adapter = new SqlDataAdapter("select * product,category from Table", sqlConnection);

            DataSet dataset = new DataSet();

            adapter.Fill(dataset);

            DG_Sql.Items.Add(dataset.Tables[0]);
        }
    }
}
