namespace MODUL3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                // Buat nampilin Show Dialog
                MessageBox.Show("Pilih satuan terlebih dahulu!");
                return;
            }

            // out --> pass by reference, parsing berhasil --> simpan ke var nilai
            if (!double.TryParse(textBox1.Text, out double nilai))
            {
                // Buat nampilin Show Dialog
                MessageBox.Show("Masukkan angka yang valid!");
                return;
            }

            string dari = comboBox1.SelectedItem.ToString().Trim();
            string ke = comboBox2.SelectedItem.ToString().Trim();

            // jadi biar ga banyak if else, pakai celcius sbg nilai tengah
            // a --> celcius, celcius --> b
            double celcius = KeCelcius(nilai, dari);
            double hasil = DariCelcius(celcius, ke);


            // 2 angka belakang koma
            textBox2.Text = hasil.ToString("F2");
        }

        // convert dlu ke celcius
        private double KeCelcius(double nilai, string satuan)
        {
            switch (satuan)
            {
                case "Celcius":
                    return nilai;

                case "Fahrenheit":
                    return (nilai - 32) * 5 / 9;

                case "Reamur":
                    return nilai * 5 / 4;

                case "Kelvin":
                    return nilai - 273.15;

                default:
                    return nilai;
            }
        }

        // dri celcius bru ke yg lain
        private double DariCelcius(double nilai, string satuan)
        {
            switch (satuan)
            {
                case "Celcius":
                    return nilai;

                case "Fahrenheit":
                    return (nilai * 9 / 5) + 32;

                case "Reamur":
                    return nilai * 4 / 5;

                case "Kelvin":
                    return nilai + 273.15;

                default:
                    return nilai;
            }
        }
    }
}
