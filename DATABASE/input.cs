using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASE
{
    class input
    {
        static public void BuatKotak(int kiri, int atas, int kanan, int bawah)
        {

            //pojok kiri atas
            Console.SetCursorPosition(kiri, atas);
            Console.Write("╔");
            //lurus
            for (int i = kiri + 1; i <= kanan; i++)
            {
                Console.SetCursorPosition(i, atas);
                Console.Write("═");
            }
            //pojok kanan atas
            Console.SetCursorPosition(kanan, atas);
            Console.Write("╗");
            //lurus kebawah
            for (int i = atas + 1; i <= bawah; i++)
            {
                Console.SetCursorPosition(kanan, i);
                Console.Write("║");
            }
            //pojok kanan bawah
            Console.SetCursorPosition(kanan, bawah);
            Console.Write("╝");
            //lurus
            for (int i = kanan - 1; i >= kiri + 1; i--)
            {
                Console.SetCursorPosition(i, bawah);
                Console.Write("═");
            }
            //pojok kiri bawah
            Console.SetCursorPosition(kiri, bawah);
            Console.Write("╚");
            //lurus atas
            for (int i = bawah - 1; i >= atas + 1; i--)
            {
                Console.SetCursorPosition(kiri, i);
                Console.Write("║");
            }
        }
        static public void tulis(int kiri, int atas, string teks)
        {
            Console.SetCursorPosition(kiri, atas);
            Console.Write(teks);
        }
        static public void tulis_warna(int kiri, int atas, string teks, ConsoleColor warnateks, ConsoleColor warnabackground)
        {
            Console.SetCursorPosition(kiri, atas);
            Console.ForegroundColor = warnateks;
            Console.BackgroundColor = warnabackground;
            Console.Write(teks);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
