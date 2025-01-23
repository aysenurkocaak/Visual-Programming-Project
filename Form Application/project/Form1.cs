using System;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VisualProje
{
    public partial class Form1 : Form
    {
        // SQLite baðlantý dizesi
        private string connectionString = @"Data Source=""C:\Users\Monster\Desktop\VisualProje\girisdb.db"";Version=3;";
        public Form1()
        {
            InitializeComponent();
        }

        // Button1: Giriþ yapma iþlemi
        private void button1_Click(object sender, EventArgs e)
        {
            // Email ve þifre boþ mu kontrol et
            if (string.IsNullOrEmpty(txtad.Text) || string.IsNullOrEmpty(txtsifre.Text))
            {
                MessageBox.Show("Email veya þifre alaný boþ býrakýlamaz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kullanýcý kontrol sorgusu
                    string query = "SELECT COUNT(*) FROM girisdb WHERE ad = @ad AND sifre = @sifre";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ad", txtad.Text);
                        command.Parameters.AddWithValue("@sifre", txtsifre.Text);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Giriþ baþarýlý!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Form2'ye geçiþ
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ad veya þifre yanlýþ.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtad.Text = string.Empty;
                            txtsifre.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            // Eðer email veya þifre boþsa, hata mesajý göster
            if (string.IsNullOrWhiteSpace(txtad.Text) || string.IsNullOrWhiteSpace(txtsifre.Text))
            {
                MessageBox.Show("Lütfen email ve þifre giriniz.", "Hata");
                return;
            }

            // Veritabaný baðlantýsý
            string dbPath = "Data Source=C:\\Users\\Monster\\Desktop\\VisualProje\\girisdb.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                try
                {
                    conn.Open(); // Baðlantýyý aç
                    string query = "INSERT INTO girisdb (ad, sifre) VALUES (@ad, @sifre)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Parametreleri ekle
                        cmd.Parameters.AddWithValue("@ad", txtad.Text);
                        cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Veriyi ekle ve eklenip eklenmediðini kontrol et

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayýt baþarýlý!", "Baþarýlý");
                        }
                        else
                        {
                            MessageBox.Show("Kayýt baþarýsýz oldu. Lütfen tekrar deneyin.", "Hata");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluþtu: {ex.Message}", "Hata");
                }
                finally
                {
                    conn.Close(); // Baðlantýyý kapat
                    txtad.Clear(); // TextBox'larý temizle
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
