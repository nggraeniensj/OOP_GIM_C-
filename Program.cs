
using System;
namespace KerangkaGame
{
    class Karakter
    {
        //public string kesehatan, senjata;
        public int totalsenjata, power;

        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        public Karakter(string nama, int kesehatan, int senjata) //membuat constructor
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("===> Mulai Serangan <===");
            target.TerimaSerangan(this.senjata);

        }

        public void TerimaSerangan(int jumlahserangan)
        {
            kesehatan -= jumlahserangan;
            Console.WriteLine($"{nama} diserang dengan {jumlahserangan}. Sisa kesehatan {kesehatan}");
        }

        public void MenambahKesehatan(int jumlahkesehatan)
        {
            kesehatan += jumlahkesehatan;
            Console.WriteLine($"Nyawa {nama} bertambah {kesehatan}");
        }

        public void getData()
        {
            Console.WriteLine($"Karakter: {nama}");
            Console.WriteLine($"Kesehatan: {kesehatan}");
            Console.WriteLine($"Senjata: {senjata}");
        }

        //Menambahkan method aksi pada class karakter, untuk perpindahan posisi dengan input posisi awal dan posisi saat ini
        public int posisi = 0;

        public void Bergerak()
        {
            Console.WriteLine("Gunakan tombol panah kanan/kiri");
            Console.WriteLine("Tekan Esc untuk berhenti bergerak.");

            while (true)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true);

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    posisi += 2;
                    Console.WriteLine($"Posisi sekarang: {posisi}");
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    if (posisi >= 2)
                    {
                        posisi -= 2;
                    }

                    Console.WriteLine($"Posisi sekarang: {posisi}");
                }
                else if (tombol.Key == ConsoleKey.UpArrow)
                {
                    posisi += 4;
                    Console.WriteLine($"Posisi sekarang: {posisi}");
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Berhenti bergerak.");
                    break;
                }
            }
        }



        public void BerpindahPosisi()
        {
            posisi = 0;

            while (true)
            {
                Console.Write("\nMau berapa langkah pindah posisi? (ketik c untuk berhenti): ");

                string input = Console.ReadLine();

                if (input.ToLower() == "c")
                {
                    Console.WriteLine("Berhenti bergerak.");
                    break;
                }

                if (int.TryParse(input, out int jumlahLangkah))
                {
                    posisi += jumlahLangkah;
                    Console.WriteLine($"Posisi sekarang: {posisi}");
                }
                else
                {
                    Console.WriteLine("Input tidak valid!");
                }
            }
        }

    }
    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Bubble", 70, 10);
            Karakter musuh = new Karakter("Balmond", 90, 20);
            // Musuh menyerang player1
            musuh.Serang(player1);


            // input pilihan penyembuhan dari pengguna
            Console.Write("\nApakah ingin menyembuhkan hero? (ya/tidak): ");
            string pilihan = Console.ReadLine().ToLower().Trim();

            if (pilihan == "ya")
            {
                player1.MenambahKesehatan(20);
            }
            else if (pilihan == "tidak")
            {
                Console.WriteLine("Nyawa tidak di tambahkan");
            }
            else
            {
                Console.WriteLine("Tidak ada pilihan");
            }



            //kanankiri
            Console.WriteLine("\nMana yang kamu pilih?");
            Console.WriteLine("1. Perpindahan Angka");
            Console.WriteLine("2. Tombol Keyboard");
            Console.Write("\nPilihanmu: ");

            string pilihanGerak = Console.ReadLine();


            if (pilihanGerak == "1")
            {
                Console.WriteLine($"Posisi awal {player1.nama}: 0");
                player1.BerpindahPosisi();
            }
            else if (pilihanGerak == "2")
            {
                player1.Bergerak();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid!");
            }

        }
    }
}
