using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace DATABASE
{
    class gurusvc
    {
        public DataTable GetAll()
        {
            string query = "SELECT nip,namaguru,jabatan FROM guru";
            AccesDB dd = new AccesDB();
            return dd.GetData(query);
        }

        public gurumodel GetByNip(string nip)
        {
            gurumodel data = null;
            string query = "SELECT nip,namaguru,jabatan FROM guru WHERE nip=@kriteria";
            AccesDB dd = new AccesDB();
            DataTable dtguru = dd.GetData(query,
                new OleDbParameter("@kriteria",nip));
            if (dtguru.Rows.Count == 1)
            {
                //ambil satu baris saja
                DataRow row = dtguru.Rows[0];
                //masukkan ke model siswa
                data = new gurumodel();
                data.nip = row["nip"].ToString();
                data.namaguru = row["namaguru"].ToString();
                data.jabatan = row["jabatan"].ToString();
            }

            return data;
        }

        public DataTable GetByName(string namaguru)
        {
            string query = "SELECT nip,namaguru,jabatan FROM guru WHERE namaguru LIKE @kriteria";
            AccesDB dd = new AccesDB();
            return dd.GetData(query,
                new OleDbParameter("@kriteria", "%" + namaguru + "%"));
        }

        public void Add(gurumodel data)
        {
            string query = "INSERT INTO guru (nip,namaguru,jabatan) VALUES (@nip,@namaguru,@jabatan)";
            AccesDB dd = new AccesDB();
            dd.Execute(query,
                new OleDbParameter("@nip", data.nip),
                new OleDbParameter("@namaguru", data.namaguru),
                new OleDbParameter("@jabatan", data.jabatan));
        }

        public void Edit(string nip, gurumodel data)
        {
            string query = "UPDATE guru SET nip=@nipbaru,namaguru=@namagurubaru WHERE nip=@nipLama";
            AccesDB dd = new AccesDB();
            dd.Execute(query,
                new OleDbParameter("@nisBaru", data.nip),
                new OleDbParameter("@namaBaru", data.namaguru),
                new OleDbParameter("@kelasBaru", data.jabatan),
                new OleDbParameter("@nisLama", nip));
        }

        public void Hapus(string nip)
        {
            string query = "DELETE FROM guru WHERE nip=@kriteria";
            AccesDB dd = new AccesDB();
            dd.Execute(query,
                new OleDbParameter("@kriteria", nip));

        }
    }
}
