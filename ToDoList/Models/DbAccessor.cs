using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class DbAccessor
    {
        public DataSet query(string query)
        {
            var connectionString = "Data Source=pc-nahuel;Initial Catalog=ToDoListHome;Integrated Security=True;Pooling=False";
            SqlConnection conn;
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dataSet = new DataSet();
                        var dataTable = new DataTable();
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);
                        return dataSet;
                    }
                }

            }
        }

        public void delete(string query,int id)
        {
            var connectionString = "Data Source=Source;Initial Catalog=NomeDB;Integrated Security=True;Pooling=False";
            SqlConnection conn;
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void insert(string query, string contenuto)
        {
            if (!String.IsNullOrEmpty(contenuto))
            {
                var connectionString = "Data Source=Source;Initial Catalog=NomeDB;Integrated Security=True;Pooling=False";
                SqlConnection conn;
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@contenuto", SqlDbType.NChar).Value = contenuto;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
