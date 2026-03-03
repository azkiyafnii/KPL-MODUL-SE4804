using System;

class Program
{
    static void Main(string[] args)
    {
        // ======================
        // 1. Input Nama
        // ======================
        Console.Write("Masukkan nama Anda: ");
        string nama = Console.ReadLine();

        Console.WriteLine("Selamat datang, " + nama + "!");
        Console.WriteLine();

        // ======================
        // 2. Array 40 Elemen
        // ======================
        int[] angka = new int[40];

        // Mengisi array dari 39 sampai 0
        int nilaiAwal = 39;

        for (int i = 0; i < 40; i++)
        {
            angka[i] = nilaiAwal;
            nilaiAwal--;
        }

        // Menampilkan isi array
        for (int i = 0; i < 40; i++)
        {
            if (angka[i] % 3 == 0 && angka[i] % 7 == 0)
            {
                Console.WriteLine("#!#!#");
            }
            else if (angka[i] % 3 == 0)
            {
                Console.WriteLine("###");
            }
            else if (angka[i] % 7 == 0)
            {
                Console.WriteLine("&&&");
            }
            else
            {
                Console.WriteLine(angka[i]);
            }
        }

        Console.WriteLine();

        // ======================
        // 3. Cek Bilangan Prima (ver pemula)
        // ======================
        Console.Write("Masukkan angka (1 - 10000): ");
        string nilaiString = Console.ReadLine();

        int nilaiInt = Convert.ToInt32(nilaiString);

        bool prima = true;

        if (nilaiInt <= 1)
        {
            prima = false;
        }
        else
        {
            for (int i = 2; i < nilaiInt; i++)
            {
                if (nilaiInt % i == 0)
                {
                    prima = false;
                    break;
                }
            }
        }

        if (prima == true)
        {
            Console.WriteLine("Angka " + nilaiInt + " merupakan bilangan prima");
        }
        else
        {
            Console.WriteLine("Angka " + nilaiInt + " bukan bilangan prima");
        }

        Console.ReadLine();

        // ======================
        // 3. Cek Bilangan Prima (ver simpel)
        // ======================

        Console.Write("Masukkan angka (1 - 10000): ");
        string nilaiS = Console.ReadLine();
        int nilaiI = Convert.ToInt32(nilaiS);

        if (IsPrime(nilaiI))
        {
            Console.WriteLine($"Angka {nilaiI} merupakan bilangan prima");
        }
        else
        {
            Console.WriteLine($"Angka {nilaiI} bukan bilangan prima");
        }
    }

    // Method untuk mengecek bilangan prima
    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}