using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace DATABASE
{
    class AccesDB
    {
         OleDbConnection koneksi;
        
        public AccesDB()
        {
            //constructor
            string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database4.accdb;";
            koneksi = new OleDbConnection(koneksiString);
            koneksi.Open();
            
        }
        public void Execute(string query, params OleDbParameter[] parameters)
        {
            OleDbCommand cmd = new OleDbCommand(query, koneksi);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        //untuk select
        public DataTable GetData(string query, params OleDbParameter[] parameters)
        {
            DataTable result = new DataTable();

            OleDbCommand cmd = new OleDbCommand(query, koneksi);
            cmd.Parameters.AddRange(parameters);
            OleDbDataReader reader = cmd.ExecuteReader();

            
            result.Load(reader);

            return result;
        }

        ~AccesDB()
        {
           // destructor
            koneksi.Close();
        }

    }
}
