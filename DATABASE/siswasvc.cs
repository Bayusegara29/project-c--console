using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
namespace DATABASE

{
    class siswasvc
    {
        public DataTable GetAll()
        {
            string query = "SELECT nis,nama,kelas FROM siswa";
            MySQLDB db = new MySQLDB();
            return db.GetData(query);
        }

        public siswamodel GetByNis(string nis)
        {
            siswamodel data = null;
            string query = "SELECT nis,nama,kelas FROM siswa WHERE nis=@kriteria";
            AccesDB db = new AccesDB();
            DataTable dtSiswa = db.GetData(query,
                new OleDbParameter("@kriteria", nis));
            if (dtSiswa.Rows.Count == 1)
            {
                //ambil satu baris saja
                DataRow row = dtSiswa.Rows[0];
                //masukkan ke model siswa
                data = new siswamodel();
                data.nis = row["nis"].ToString();
                data.nama = row["nama"].ToString();
                data.kelas = row["kelas"].ToString();
            }

            return data;
        }

        public DataTable GetByName(string nama)
        {
            string query = "SELECT nis,nama,kelas FROM siswa WHERE nama LIKE @kriteria";
            MySQLDB db = new MySQLDB();
            return db.GetData(query,
                new MySqlParameter("@kriteria", "%" + nama + "%"));
        }

        public void Add(siswamodel data)
        {
            string query = "INSERT INTO siswa (nis,nama,kelas) VALUES (@nis,@nama,@kelas)";
            MySQLDB db = new MySQLDB();
            db.Execute(query,
                new MySqlParameter("@nis", data.nis),
                new MySqlParameter("@nama", data.nama),
                new MySqlParameter("@kelas", data.kelas));
        }

        public void Edit(string nis, siswamodel data)
        {
            string query = "UPDATE siswa SET nis=@nisBaru,nama=@namaBaru,kelas=@kelasBaru WHERE nis=@nisLama";
            MySQLDB db = new MySQLDB();
            db.Execute(query,
                new MySqlParameter("@nisBaru", data.nis),
                new MySqlParameter("@namaBaru", data.nama),
                new MySqlParameter("@kelasBaru", data.kelas),
                new MySqlParameter("@nisLama", nis));
        }

        public void Hapus(string nis)
        {
            string query = "DELETE FROM siswa WHERE nis=@kriteria";
            MySQLDB db = new MySQLDB();
            db.Execute(query,
                new MySqlParameter("@kriteria", nis));

        }
    }
}
