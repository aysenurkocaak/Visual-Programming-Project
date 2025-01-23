using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualProje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            // 1. Mobilya adı ve adet girişlerini kontrol et
            if (string.IsNullOrWhiteSpace(txtmob.Text))
            {
                MessageBox.Show("Lütfen bir mobilya adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtsayi.Text, out int adet) || adet <= 0)
            {
                MessageBox.Show("Lütfen geçerli ve pozitif bir adet giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. SQLite bağlantı dizesi
            string connectionString = @"Data Source=""C:\Users\Monster\Desktop\VisualProje\mobilyadb.db"";Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // 3. Bağlantıyı aç
                    connection.Open();

                    // 4. Mobilyanın zaten mevcut olup olmadığını kontrol et
                    string selectQuery = "SELECT adet FROM mobilyadb WHERE mobilya = @mobilya";
                    using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@mobilya", txtmob.Text);

                        object result = selectCommand.ExecuteScalar();

                        if (result != null)
                        {
                            // 5. Mobilya zaten mevcut, mevcut adedi güncelle
                            int mevcutAdet = Convert.ToInt32(result);
                            int yeniAdet = mevcutAdet + adet;

                            string updateQuery = "UPDATE mobilyadb SET adet = @adet WHERE mobilya = @mobilya";
                            using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@adet", yeniAdet);
                                updateCommand.Parameters.AddWithValue("@mobilya", txtmob.Text);

                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Mevcut kayıt güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Kayıt güncellenemedi. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            // 6. Mobilya mevcut değil, yeni kayıt ekle
                            string insertQuery = "INSERT INTO mobilyadb (mobilya, adet) VALUES (@mobilya, @adet)";
                            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@mobilya", txtmob.Text);
                                insertCommand.Parameters.AddWithValue("@adet", adet);

                                int rowsAffected = insertCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Yeni kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Kayıt eklenemedi. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // 7. Bağlantıyı kapat ve giriş alanlarını temizle
                    connection.Close();
                    txtmob.Clear();
                    txtsayi.Clear();
                }
            }
        }

        private void btncikart_Click(object sender, EventArgs e)
        {
            // Mobilya adı ve adet alanlarının boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtmob.Text) || string.IsNullOrWhiteSpace(txtsayi.Text))
            {
                MessageBox.Show("Lütfen mobilya adı ve adet giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Adet sayısının geçerli bir sayı olup olmadığını kontrol et
            if (!int.TryParse(txtsayi.Text, out int cikartAdet))
            {
                MessageBox.Show("Adet geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bağlantı dizesi
            string connectionString = @"Data Source=C:\Users\Monster\Desktop\VisualProje\mobilyadb.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Mobilyanın mevcut olup olmadığını kontrol et
                    string selectQuery = "SELECT adet FROM mobilyadb WHERE mobilya = @mobilya";
                    using (SQLiteCommand selectCmd = new SQLiteCommand(selectQuery, connection))
                    {
                        selectCmd.Parameters.AddWithValue("@mobilya", txtmob.Text);

                        object result = selectCmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Mevcut adet değerini al
                            int mevcutAdet = Convert.ToInt32(result);

                            if (mevcutAdet < cikartAdet)
                            {
                                MessageBox.Show("Stokta yeterli mobilya yok!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                int yeniAdet = mevcutAdet - cikartAdet;

                                if (yeniAdet == 0)
                                {
                                    // Yeni adet sıfırsa, veriyi sil
                                    string deleteQuery = "DELETE FROM mobilyadb WHERE mobilya = @mobilya";
                                    using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, connection))
                                    {
                                        deleteCmd.Parameters.AddWithValue("@mobilya", txtmob.Text);
                                        deleteCmd.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Mobilya stok sıfırlandı ve veritabanından silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    // Yeni adet değerini güncelle
                                    string updateQuery = "UPDATE mobilyadb SET adet = @yeniAdet WHERE mobilya = @mobilya";
                                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, connection))
                                    {
                                        updateCmd.Parameters.AddWithValue("@yeniAdet", yeniAdet);
                                        updateCmd.Parameters.AddWithValue("@mobilya", txtmob.Text);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Mobilya adedi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu mobilya veritabanında bulunmamaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                    // TextBox'ları temizle
                    txtmob.Clear();
                    txtsayi.Clear();
                }
            }
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            // SQLite bağlantı dizesi
            string connectionString = @"Data Source=C:\Users\Monster\Desktop\VisualProje\mobilyadb.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // mobilyadb'deki tüm verileri seç
                    string query = "SELECT mobilya, adet FROM mobilyadb";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Form3'ü oluştur ve göster
                        Form3 form3 = new Form3();

                        // Form3'teki Chart kontrolünü al
                        Chart chart = form3.Controls["chartMobilya"] as Chart;

                        if (chart != null)
                        {
                            // Chart'ın ayarlarını temizle ve yeniden başlat
                            chart.Series.Clear();
                            chart.Titles.Clear();
                            chart.Titles.Add("Mobilya ve Adet Grafiği");

                            // Yeni bir seri oluştur ve ayarla
                            Series series = new Series
                            {
                                Name = "Adet",
                                ChartType = SeriesChartType.Bar // Bar (sütun) grafik tipi
                            };

                            chart.Series.Add(series);

                            // Verileri grafiğe ekle
                            while (reader.Read())
                            {
                                string mobilya = reader["mobilya"].ToString();
                                int adet = Convert.ToInt32(reader["adet"]);

                                series.Points.AddXY(mobilya, adet);
                            }
                        }

                        // Form3'ü göster
                        form3.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
