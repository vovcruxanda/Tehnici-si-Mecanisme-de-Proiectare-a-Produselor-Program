using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DairyFarmSystem
{
    internal class DatabaseFacade
    {
        private readonly SqlConnection _connection;

        public DatabaseFacade(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public DataTable ExecuteSelectQuery(string query)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, _connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public void ExecuteNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.ExecuteNonQuery();
        }
    }
}
