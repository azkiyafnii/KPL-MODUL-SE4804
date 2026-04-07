using System;
using System.Collections.Generic;

internal class Program
{
    class PemrosesData
    {
        public T DapatkanNilaiTerbesar<T>(T angka1, T angka2, T angka3)
        {
            dynamic temp1 = (dynamic)angka1;
            dynamic temp2 = (dynamic)angka2;
            dynamic temp3 = (dynamic)angka3;
            dynamic largest = temp1;

            if (temp2 > largest)
                largest = temp2;
            if (temp3 > largest)
                largest = temp3;

            return largest;
        }
    }

    class SimpleDataBase<T>
    {
        private List<T> storedData;
        private List<DateTime> inputDates;

        public SimpleDataBase()
        {
            storedData = new List<T>();
            inputDates = new List<DateTime>();
        }

        public void AddNewData(T data)
        {
            storedData.Add(data);
            DateTime currentTime = DateTime.Now;
            inputDates.Add(currentTime);
        }

        public void PrintAllData()
        {
            for (int i = 0; i < storedData.Count; i++)
            {
                Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
            }
        }
    }

    private static void Main(string[] args)
    {
        PemrosesData pemroses = new PemrosesData();
        int terbesar = pemroses.DapatkanNilaiTerbesar(12, 34, 56);
        Console.WriteLine($"Nilai Terbesar: {terbesar}");

        SimpleDataBase<int> data = new SimpleDataBase<int>();
        data.AddNewData(12);
        data.AddNewData(34);
        data.AddNewData(56);
        data.PrintAllData();
    }
}
