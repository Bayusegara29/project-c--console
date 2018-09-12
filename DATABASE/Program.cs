using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DATABASE
{
    class Program
    {
        static void Main(string[] args)
        {
            input.BuatKotak(6, 1, 113, 10);
            input.BuatKotak(6, 11, 20, 35);
            input.BuatKotak(22, 11, 46, 35);
            input.BuatKotak(48, 11, 113, 35);


            string judul = "Selamat Belajar";
            input.tulis_warna((120 - judul.Length) / 2, 2, judul, ConsoleColor.Green, ConsoleColor.Black);
            string subjudul = "FROM PROGAMER TO PROGAMMER";
            input.tulis((120 - subjudul.Length) / 2, 4, subjudul);

            input.tulis(9, 12, "PILIHAN");
            //aray pati nggnah
            string[] menu = new string[7];
            menu[0] = "::Siswa::";
            menu[1] = "::Dosen::";
            menu[2] = "::Biaya::";
            menu[3] = "::Matkul::";
            menu[4] = "::nilai::";
            menu[5] = "::Absen::";
            menu[6] = "::Lulus::";

            for (int i = 1; i < 7; i++)
            {
                input.tulis(9, 13 + i, menu[i]);
            }
            int pilihan = 0;
            input.tulis_warna(9, 13, menu[pilihan], ConsoleColor.Black, ConsoleColor.Green);
            //pencet tombol

            ConsoleKeyInfo tombol;
            do
            {
                tombol = Console.ReadKey(true);
                if (tombol.Key == ConsoleKey.DownArrow)
                {
                    input.tulis_warna(9, 13 + pilihan, menu[pilihan], ConsoleColor.White, ConsoleColor.Black);
                    pilihan++;
                    if (pilihan == 7)
                    {
                        pilihan = 0;
                    }

                    input.tulis_warna(9, 13 + pilihan, menu[pilihan], ConsoleColor.Black, ConsoleColor.Green);
                }
                if (tombol.Key == ConsoleKey.UpArrow)
                {
                    input.tulis_warna(9, 13 + pilihan, menu[pilihan], ConsoleColor.White, ConsoleColor.Black);
                    pilihan--;
                    if (pilihan == -1)
                    {
                        pilihan = 6;
                    }
                    input.tulis_warna(9, 13 + pilihan, menu[pilihan], ConsoleColor.Black, ConsoleColor.Green);
                }


                if (tombol.Key == ConsoleKey.Enter)
                {
                    if (pilihan == 0)
                    {
                        input.tulis(23, 12, "Pengolahan Data Siswa");
                        input.tulis(23, 13, "=====================");
                        Console.SetCursorPosition(23, 14);
                        string[] pilihansiswa = new string[4];
                        pilihansiswa[0] = "Tambah Data Siswa";
                        pilihansiswa[1] = "Tampil Data Siswa";
                        pilihansiswa[2] = "Edit Data Siswa";
                        pilihansiswa[3] = "Hapus Data Siswa";
                        
                        for (int i = 1; i < 4; i++)
                        {
                            input.tulis(23, 14 + i, pilihansiswa[i]);
                        }
                        int opsi = 0;
                        input.tulis_warna(23, 14, pilihansiswa[opsi], ConsoleColor.White, ConsoleColor.Magenta);
                        ConsoleKeyInfo pencet;
                        do
                        {
                            pencet = Console.ReadKey(true);
                            if (pencet.Key == ConsoleKey.DownArrow)
                            {
                                input.tulis_warna(23, 14 + opsi, pilihansiswa[opsi], ConsoleColor.White, ConsoleColor.Black);
                                
                                if (opsi == 3)
                                {
                                    opsi = 0;
                                }
                                else { opsi++; }
                                input.tulis_warna(23, 14 + opsi, pilihansiswa[opsi], ConsoleColor.White, ConsoleColor.Magenta);
                            }
                            if (pencet.Key == ConsoleKey.UpArrow)
                            {
                                input.tulis_warna(23, 14 + opsi, pilihansiswa[opsi], ConsoleColor.White, ConsoleColor.Black);
                                
                                if (opsi == 0)
                                {
                                    opsi = 3;
                                }
                                else { opsi--; }

                                input.tulis_warna(23, 14 + opsi, pilihansiswa[opsi], ConsoleColor.White, ConsoleColor.Magenta);
                            }
                            if (pencet.Key == ConsoleKey.Enter)
                            {
                                if (opsi == 0)
                                {
                                    siswamodel data = new siswamodel();
                                    input.tulis(50, 12, "Masukan data siswa");
                                    input.tulis(50, 13, "Nis:");
                                    data.nis = Console.ReadLine();
                                    input.tulis(50, 14, "Nama:");
                                    data.nama = Console.ReadLine();
                                    input.tulis(50, 15, "Kelas:");
                                    data.kelas = Console.ReadLine();
                                    input.tulis(50, 16, "Mau simpan data?[Y/N]:");
                                    string jawab = Console.ReadLine();
                                    if (jawab.ToUpper() == "Y")
                                    {
                                        //TAMBAH KE DATABASE
                                        siswasvc siswa = new siswasvc();
                                        siswa.Add(data);
                                    }
                                    //Console.SetCursorPosition;
                                    /*
                                    if (jawab.ToUpper() == "Y")
                                    {                                     
                                            string query = "INSERT INTO siswa (nim,nama,kelas)Values (@nim,@nama,@kelas)";
                                            string konekstring = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Data.accdb";
                                            OleDbConnection koneksi = new OleDbConnection(konekstring);
                                            koneksi.Open();
                                            OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                            cmd.Parameters.AddWithValue("Nim", nim);
                                            cmd.Parameters.AddWithValue("Nama", nama);
                                            cmd.Parameters.AddWithValue("Kelas", kelas);
                                            cmd.ExecuteNonQuery(); 
                                    }
                                     * */
                                    for (int i = 0; i < 5; i++)
                                    {
                                        input.tulis(50, 12 + i, "                              ");
                                    }
                                }
                                else if (opsi == 1)
                                {
                                    input.tulis(50, 12, ">>Tampil data siswa");
                                    input.tulis(50, 13, "===================");
                                    input.tulis(50, 14, "Masukan nama atau kosongi untuk tampilkan semua data:");
                                    string cari = Console.ReadLine();
                                    //procedural
                                    /*
                                    
                                    string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                                    OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                    koneksi.Open();

                                    
                                    string query;
                                    if (cari == "")
                                    {
                                        query = "SELECT nis,nama,kelas FROM siswa ";
                                    }
                                    else
                                    {
                                        query = "SELECT nis,nama,kelas FROM siswa WHERE nama LIKE '%"+ cari +"%'";
                                    }

                                    OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                    OleDbDataReader reader = cmd.ExecuteReader();

                                    //menampung dalam data tabel
                                    DataTable dtSiswa = new DataTable();
                                    dtSiswa.Load(reader);
                                    */
                                    

                                    siswasvc siswa = new siswasvc();
                                    DataTable dtSiswa;
                                    if (cari == "")
                                        dtSiswa = siswa.GetAll();
                                    else
                                        dtSiswa = siswa.GetByName(cari);
                                    Console.WriteLine();

                                    if (dtSiswa.Rows.Count > 0)
                                    {
                                        //tampilkan data jika ada data
                                        /*
                                            for (int i = 0; i < dtSiswa.Rows.Count; i++)
                                            {
                                                DataRow row = dtSiswa.Rows[i];
                                                string teks = string.Format(" | {0} | {1,-30} | {2,-5} | ",
                                                    row["nis"], row["nama"], row["kelas"]);
                                                input.tulis(50, 18 + i, teks);
                                            }

                                            Console.ReadKey();*/
                                        input.tulis(54, 18, "NIS");
                                        input.tulis(70, 18, "        NAMA");
                                        input.tulis(103, 18, "KELAS");
                                        input.BuatKotak(52, 17, 60, 33);
                                        input.BuatKotak(60, 17, 102, 33);
                                        input.BuatKotak(102, 17, 110, 33);
                                        for (int i = 53; i < 110; i++)
                                        {
                                            input.tulis(i, 19, "═");
                                        }
                                        input.tulis(60, 17, "╦");
                                        input.tulis(102, 17, "╦");
                                        input.tulis(60, 19, "╬");
                                        input.tulis(102, 19, "╬");
                                        input.tulis(52, 19, "╠");
                                        input.tulis(110, 19, "╣");
                                        input.tulis(60, 33, "╩");
                                        input.tulis(102, 33, "╩");
                                        int baris = 20;
                                        foreach (DataRow row in dtSiswa.Rows)
                                        {
                                            input.tulis(53, baris, row["nis"].ToString());
                                            input.tulis(62, baris, row["nama"].ToString());
                                            input.tulis(104, baris, row["kelas"].ToString());
                                            baris++;
                                            if (baris == 32)
                                            {
                                                input.tulis(52, 34, "Tekan Tombol Untuk Melanjutkan");
                                                Console.ReadKey();
                                                for (int i = 20; i < 32; i++)
                                                {
                                                    input.tulis(53, i, "    ");    
                                                    input.tulis(61, i, "        ");
                                                    input.tulis(103, i,                   "      ");
                                                }
                                                baris = 20;
                                            }
                                        }
                                        Console.ReadKey();
                                        for (int i = 0; i < 23; i++)
                                        {
                                            input.tulis(50, 12 + i, "                                                             ");
                                        }            
                                    }
                                    else
                                    {
                                        input.tulis(50, 16, "Data tidak ditemukan");
                                    }                              
                                }
                                else if (opsi == 2)
                                {
                                    /*
                                    string query = "SELECT * FROM siswa WHERE nis=@nis";
                                    string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                                    OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                    koneksi.Open();

                                    OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                    cmd.Parameters.AddWithValue("@nis", nisLama);
                                    OleDbDataReader baca = cmd.ExecuteReader();

                                    DataTable dtSiswa = new DataTable();
                                    dtSiswa.Load(baca);

                            if (dtSiswa.Rows.Count == 1)
                            { 
                                //tampilkan data lama
                                DataRow row = dtSiswa.Rows[0];
                                Console.WriteLine("Nis   : " + row["nis"] );
                                Console.WriteLine("Nama  : " + row["nama"]);
                                Console.WriteLine("Kelas : " + row["kelas"]);

                                //input data baru
                                Console.WriteLine();
                                Console.Write("Nis Baru   : ");
                                string nisBaru = Console.ReadLine();
                                Console.Write("Nama Baru  : ");
                                string nama = Console.ReadLine();
                                Console.Write("Kelas Baru : ");
                                string kelas = Console.ReadLine();

                                Console.Write("Update data siswa : [Y/N] ");
                                string jawab = Console.ReadLine();
                                if (jawab.ToUpper() == "Y")
                                {
                                    query = "UPDATE siswa SET nis=@nisBaru,nama=@nama,kelas=@kelas WHERE nis=@nis";
                                    cmd = new OleDbCommand(query, koneksi);

                                    cmd.Parameters.AddWithValue("@nisBaru", nisBaru);
                                    cmd.Parameters.AddWithValue("@nama", nama);
                                    cmd.Parameters.AddWithValue("@kelas", kelas);
                                    cmd.Parameters.AddWithValue("@nis", nisLama);
                                    
                                    cmd.ExecuteNonQuery();
                                */
                                    //oop
                                    input.tulis(50, 12, "3.Edit data siswa");
                                    input.tulis(50, 13, " Masukan nis yang ingin diedit:");
                                    string nisLama = Console.ReadLine();
                                    siswamodel data = new siswamodel();
                                    
                                    input.tulis(50,14,">> Input Data Siswa");
                                    input.tulis(50, 15, "NIS      : ");
                                    data.nis = Console.ReadLine();
                                    input.tulis(50,16,"NAMA     : ");
                                    data.nama = Console.ReadLine();
                                    input.tulis(50, 17, "KELAS    : ");
                                    data.kelas = Console.ReadLine();

                                    input.tulis(50, 18, "Simpan Data ? [Y/N] ");
                                    string jawab = Console.ReadLine();

                                    if (jawab.ToUpper() == "Y")
                                    {

                                        
                                        //tambah ke database
                                        siswasvc siswa = new siswasvc();
                                        siswa.Edit(data.nis,data);
                                    }
                                    
                                    for (int i = 0; i <= 7; i++)
                                    {
                                        input.tulis(50, 12 + i, "                                                          ");
                                    }
                                }
                                else if (opsi == 3)
                                {
                                    input.tulis(50, 12, "4.Hapus data");
                                    input.tulis(50, 13, "Masukan nis yang ingin dihapus:");
                                    string nis = Console.ReadLine();
                                    input.tulis(50, 14, " Hapus Data siswa? [Y/N] ");
                                    string jawab = Console.ReadLine();
                                    if (jawab.ToUpper() == "Y")
                                    {
                                        // procedural
                                        /*
                                        string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
                                        OleDbConnection koneksi = new OleDbConnection(koneksiString);
                                        koneksi.Open();

                                        string query = "DELETE FROM siswa WHERE nis=@nis";
                                        OleDbCommand cmd = new OleDbCommand(query, koneksi);
                                        cmd.Parameters.AddWithValue("@nis", nis);
                                        cmd.ExecuteNonQuery();
                                        */
                                        //oop
                                        siswasvc siswa = new siswasvc();
                                        siswa.Hapus(nis);
                                        input.tulis(50, 16, "Data berhasil dihapus");
                                        input.tulis(50, 17, "Tekan tombol untuk lanjut");
                                    }

                                    for (int i = 0; i <= 3; i++)
                                    {
                                        input.tulis(50, 12 + i, "                                                          ");
                                    }
                                }
                            }
                            
                        } while (pencet.Key != ConsoleKey.Backspace);
                        for (int i = 0; i < 7; i++)
                        {
                            input.tulis(23, 12 + i, "                       ");
                        }
                    }
                    else if (pilihan == 1)
                    {
                        input.tulis(23, 12, ">>Pengolahan Data Dosen");
                        input.tulis(23, 13, "=======================");
                        Console.SetCursorPosition(23, 14);
                        string[] menuguru = new string[4];
                        menuguru[0]= "Tambah data guru";
                        menuguru[1] = "Tampil Data guru";
                        menuguru[2] = "Edit data guru";
                        menuguru[3] = "Hapus data guru";
                        for (int i = 1; i < 4; i++)
                        {
                            input.tulis(23, 14 + i, menuguru[i]);
                        }
                        int opsi = 0;
                        input.tulis_warna(23, 14, menuguru[opsi], ConsoleColor.White, ConsoleColor.Magenta);
                        ConsoleKeyInfo pencet;
                        do
                        {
                            pencet = Console.ReadKey(true);
                            if (pencet.Key == ConsoleKey.DownArrow)
                            {
                                input.tulis_warna(23, 14 + opsi, menuguru[opsi], ConsoleColor.White, ConsoleColor.Black);

                                if (opsi == 3)
                                {
                                    opsi = 0;
                                }
                                else { opsi++; }
                                input.tulis_warna(23, 14 + opsi, menuguru[opsi], ConsoleColor.White, ConsoleColor.Magenta);
                            }
                            if (pencet.Key == ConsoleKey.UpArrow)
                            {
                                input.tulis_warna(23, 14 + opsi, menuguru[opsi], ConsoleColor.White, ConsoleColor.Black);

                                if (opsi == 0)
                                {
                                    opsi = 3;
                                }
                                else { opsi--; }

                                input.tulis_warna(23, 14 + opsi, menuguru[opsi], ConsoleColor.White, ConsoleColor.Magenta);
                            }
                            if (pencet.Key == ConsoleKey.Enter)
                            {
                                if (opsi == 0)
                                {
                                    gurumodel data = new gurumodel();
                                    input.tulis(50, 12, "1.Tambah Data guru");
                                    input.tulis(50, 13, "===================");
                                    input.tulis(50, 14, "NIS:");
                                    data.nip = Console.ReadLine();
                                    input.tulis(50, 15, "Nama:");
                                    data.namaguru = Console.ReadLine();
                                    input.tulis(50, 16, "Jabatan:");
                                    data.jabatan = Console.ReadLine();
                                    input.tulis(50, 17, "Mau Simpan Data?[Y/N]:");
                                    string jawab = Console.ReadLine();
                                    if (jawab.ToUpper() == "Y")
                                    {
                                        gurusvc guru = new gurusvc();
                                        guru.Add(data);
                                    }
                                    for(int i= 0;i<7;i++)
                                    input.tulis(50, 12+i, "                                         ");
                                }
                                else if (opsi == 1)
                                {
                                    input.tulis(50, 12, "2.Tampil data Siswa");
                                    input.tulis(50, 13, "===================");
                                    input.tulis(50, 14, "Masukan Nama atau kosongi untuk tampilkan semua data:");
                                    string cari = Console.ReadLine();
                                    gurusvc guru = new gurusvc();
                                    DataTable dtguru;
                                    if (cari == "")
                                    {
                                        dtguru = guru.GetAll();
                                    }
                                    else
                                    {
                                        dtguru = guru.GetByName(cari);
                                    }
                                    if (dtguru.Rows.Count > 0)
                                    {
                                        input.tulis(54, 18, " NIP");
                                        input.tulis(70, 18, "NAMAGURU");
                                        input.tulis(91, 18, " JABATAN");
                                        input.BuatKotak(52, 17, 60, 28);
                                        input.BuatKotak(60, 17, 90, 28);
                                        input.BuatKotak(90, 17, 100, 28);
                                        for (int i = 53; i < 100; i++)
                                        {
                                            input.tulis(i, 19, "═");
                                        }
                                        input.tulis(60, 17, "╦");
                                        input.tulis(90, 17, "╦");
                                        input.tulis(60, 19, "╬");
                                        input.tulis(90, 19, "╬");
                                        input.tulis(52, 19, "╠");
                                        input.tulis(100, 19, "╣");
                                        input.tulis(60, 28, "╩");
                                        input.tulis(90, 28, "╩");
                                        int baris = 20;
                                        foreach (DataRow row in dtguru.Rows)
                                        {
                                            input.tulis(53, baris, row["nip"].ToString());
                                            input.tulis(62, baris, row["namaguru"].ToString());
                                            input.tulis(91, baris, row["jabatan"].ToString());
                                            baris++;
                                            if (baris == 28)
                                            {
                                                input.tulis(52, 30, "Tekan Tombol Untuk Melanjutkan");
                                                Console.ReadKey();
                                                for (int i = 20; i < 28; i++)
                                                {
                                                    input.tulis(53, i, "    ");    
                                                    input.tulis(61, i, "        ");
                                                    input.tulis(91, i,                   "      ");
                                                }
                                                baris = 20;
                                            }
                                        }
                                        Console.ReadKey();
                                        for (int i = 0; i < 23; i++)
                                        {
                                            input.tulis(50, 12 + i, "                                                             ");
                                        }            
                                    }
                                    else
                                    {
                                        input.tulis(50, 16, "Data tidak ditemukan");
                                    }
                                }
                                else if (opsi == 2)
                                {
                                    input.tulis(50, 12, "3.Edit data Siswa");
                                    input.tulis(50, 13, "================");
                                    input.tulis(50, 14, "Masukan nip yang ingin diedit:");
                                    string nipLama = Console.ReadLine();
                                    gurumodel data = new gurumodel();
                                    input.tulis(50, 15, "Nip baru:");
                                    data.nip = Console.ReadLine();
                                    input.tulis(50, 16, "Nama baru:");
                                    data.namaguru = Console.ReadLine();
                                    input.tulis(50, 17, "Jabatan :");
                                    data.jabatan = Console.ReadLine();
                                    input.tulis(50, 18, "Simpan data baru?[Y/N]:");
                                    string jawab = Console.ReadLine();
                                    if (jawab.ToUpper() == "Y")
                                    {
                                        gurusvc guru = new gurusvc();
                                        guru.Edit(data.nip,data);
                                    }
                                    
                                    for (int i = 0; i <= 7; i++)
                                    {
                                        input.tulis(50, 12 + i, "                                                          ");
                                    }
                                }
                                else if (opsi == 3)
                                {
                                    input.tulis(50, 12, "4.Hapus Data");
                                    input.tulis(50, 13, "============");
                                    input.tulis(50, 14, "Masukan nip yang ingin dihapus:");
                                    string nip = Console.ReadLine();
                                    input.tulis(50, 15, "Yakin mau hapus data?[Y/N]:");
                                    string jawab = Console.ReadLine();
                                    if (jawab.ToUpper() == "Y")
                                    {
                                        input.tulis(50, 16, "Data berhasil dihapus");
                                        input.tulis(50, 17, "Tekan tombol untuk lanjut");
                                        gurusvc guru = new gurusvc();
                                        guru.Hapus(nip);                                      
                                    }                                    
                                    
                                    for (int i = 0; i < 7; i++)
                                    {
                                        input.tulis(50, 12 + i, "                                      ");
                                    }
                                }
                                
                            }
                        } while (pencet.Key != ConsoleKey.Backspace);
                        for (int i = 0; i < 7; i++)
                        {
                            input.tulis(23, 12 + i, "                       ");
                        }
                    }
                }
            } while (tombol.Key != ConsoleKey.End);
            
        }
    }
}
