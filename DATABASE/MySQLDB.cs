using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace DATABASE
{
    class MySQLDB
    {
        MySqlConnection koneksi;

        public MySQLDB()
        {
            string konekstring = "Server=127.0.0.1;user=root;password=;database=sekolah";
            koneksi = new MySqlConnection(konekstring);
            koneksi.Open();
        }
        public void Execute(string query, params MySqlParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

       
        public DataTable GetData(string query, params MySqlParameter[] parameters)
        {
            DataTable result = new DataTable();

            MySqlCommand cmd = new MySqlCommand (query, koneksi);
            cmd.Parameters.AddRange(parameters);
            MySqlDataReader reader = cmd.ExecuteReader();

            
            result.Load(reader);

            return result;
        }

        ~MySQLDB()
        {
           
            koneksi.Close();
        }
        

    }
}
