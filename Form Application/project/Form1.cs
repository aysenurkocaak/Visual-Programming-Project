using System;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VisualProje
{
    public partial class Form1 : Form
    {
        // SQLite ba�lant� dizesi
        private string connectionString = @"Data Source=""C:\Users\Monster\Desktop\VisualProje\girisdb.db"";Version=3;";
        public Form1()
        {
            InitializeComponent();
        }

        // Button1: Giri� yapma i�lemi
        private void button1_Click(object sender, EventArgs e)
        {
            // Email ve �ifre bo� mu kontrol et
            if (string.IsNullOrEmpty(txtad.Text) || string.IsNullOrEmpty(txtsifre.Text))
            {
                MessageBox.Show("Email veya �ifre alan� bo� b�rak�lamaz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kullan�c� kontrol sorgusu
                    string query = "SELECT COUNT(*) FROM girisdb WHERE ad = @ad AND sifre = @sifre";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ad", txtad.Text);
                        command.Parameters.AddWithValue("@sifre", txtsifre.Text);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Giri� ba�ar�l�!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Form2'ye ge�i�
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ad veya �ifre yanl��.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtad.Text = string.Empty;
                            txtsifre.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata olu�tu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            // E�er email veya �ifre bo�sa, hata mesaj� g�ster
            if (string.IsNullOrWhiteSpace(txtad.Text) || string.IsNullOrWhiteSpace(txtsifre.Text))
            {
                MessageBox.Show("L�tfen email ve �ifre giriniz.", "Hata");
                return;
            }

            // Veritaban� ba�lant�s�
            string dbPath = "Data Source=C:\\Users\\Monster\\Desktop\\VisualProje\\girisdb.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                try
                {
                    conn.Open(); // Ba�lant�y� a�
                    string query = "INSERT INTO girisdb (ad, sifre) VALUES (@ad, @sifre)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Parametreleri ekle
                        cmd.Parameters.AddWithValue("@ad", txtad.Text);
                        cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Veriyi ekle ve eklenip eklenmedi�ini kontrol et

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kay�t ba�ar�l�!", "Ba�ar�l�");
                        }
                        else
                        {
                            MessageBox.Show("Kay�t ba�ar�s�z oldu. L�tfen tekrar deneyin.", "Hata");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata olu�tu: {ex.Message}", "Hata");
                }
                finally
                {
                    conn.Close(); // Ba�lant�y� kapat
                    txtad.Clear(); // TextBox'lar� temizle
                    txtsifre.Clear();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
