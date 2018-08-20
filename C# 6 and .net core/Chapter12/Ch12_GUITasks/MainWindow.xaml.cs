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

namespace Ch12_GUITasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void BtnGetProducts_OnClick(object sender, RoutedEventArgs e)
        //{
        //    string connStr = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=true";
        //    var conn=new SqlConnection(connStr);
        //    conn.Open();
        //    var cmd=new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "WAITFOR DELAY '00:00:05';SELECT ProductID, ProductName, UnitPrice FROM Products";
        //    SqlDataReader reader= cmd.ExecuteReader();
        //    int indexOfId = reader.GetOrdinal("ProductID");
        //    int indexOfName = reader.GetOrdinal("ProductName");
        //    int indexOfUnitPrice = reader.GetOrdinal("UnitPrice");
        //    while (reader.Read())
        //    {
        //        lbProducts.Items.Add(
        //            $"{reader.GetInt32(indexOfId)}:{reader.GetString(indexOfName)}需要{reader.GetDecimal(indexOfUnitPrice)}");
        //    }
        //    reader.Dispose();
        //    conn.Dispose();

        //}
        /// <summary>
        /// 异步版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnGetProducts_OnClick(object sender, RoutedEventArgs e)
        {
            string connStr = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=true";
            var conn = new SqlConnection(connStr);
            await conn.OpenAsync();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "WAITFOR DELAY '00:00:05';SELECT ProductID, ProductName, UnitPrice FROM Products";
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            int indexOfId = reader.GetOrdinal("ProductID");
            int indexOfName = reader.GetOrdinal("ProductName");
            int indexOfUnitPrice = reader.GetOrdinal("UnitPrice");
            while (await reader.ReadAsync())
            {
                lbProducts.Items.Add(
                    $"{await reader.GetFieldValueAsync<int>(indexOfId)}:{await reader.GetFieldValueAsync<string>(indexOfName)}需要{await reader.GetFieldValueAsync<decimal>(indexOfUnitPrice)}");
            }
            reader.Dispose();
            conn.Dispose();

        }
    }
}
