using System;
using static System.Console;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Ch08Rdbms
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = @"server=(localdb)\mssqllocaldb;database=northwind;trusted_connection=true" ;
            var connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            var conn = new SqlConnection(connectionString);
            conn.Open();
            WriteLine($"数据库状态：{conn.State}");
            ListAllCategories(conn);//展示所有种类
            WriteLine($"请输入一个新的种类：");
            var newCategory = ReadLine();
            if (newCategory.Length>15)
            {
                newCategory = newCategory.Substring(0, 15);
            }
            InsertCategory(conn, newCategory);
            ListAllCategories(conn);//展示所有种类
            DeleteCategory(conn, newCategory);
            ListAllCategories(conn);//展示所有种类
            conn.Close();
            WriteLine($"数据库状态：{conn.State}");

            Read();
        }

        static void ListAllCategories(SqlConnection conn)
        {
            var cmdText = @"select * from Categories";
            var getCategories = new SqlCommand(cmdText,conn);
            SqlDataReader reader = getCategories.ExecuteReader();

            int indexOfId = reader.GetOrdinal("CategoryId");
            int indexOfName = reader.GetOrdinal("CategoryName");
            while (reader.Read())
            {
                WriteLine($"{reader.GetInt32(indexOfId)}：{reader.GetString(indexOfName)}");

            }
            reader.Close();
        }

        static void InsertCategory(SqlConnection conn,string categoryName)
        {
            var cmdText = @"insert into Categories(CategoryName) values(@CategoryName)";
            var insertCmd = new SqlCommand(cmdText, conn);
            insertCmd.Parameters.AddWithValue("@CategoryName", categoryName);
            int affectedRows = insertCmd.ExecuteNonQuery();
            WriteLine($"共插入{affectedRows}条数据");
        }

        static void DeleteCategory(SqlConnection conn, string categoryName)
        {
            var cmdText = @"delete from Categories where CategoryName=@CategoryName";
            var deleteCmd = new SqlCommand(cmdText, conn);
            deleteCmd.Parameters.AddWithValue("@CategoryName", categoryName);
            int affectedRows = deleteCmd.ExecuteNonQuery();
            WriteLine($"共删除{affectedRows}条数据");
        }
    }
}
