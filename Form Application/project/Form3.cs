using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualProje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            GrafikGoster();
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            // Form2'yi göster
            Form2 form2 = new Form2();
            form2.Show();

            // Mevcut formu (Form3) kapat
            this.Close();
        }

        private void grafik_Click(object sender, EventArgs e)
        {

        }

        private void GrafikGoster()
        {
            // SQLite bağlantı dizesi
            string connectionString = @"Data Source=C:\Users\Monster\Desktop\VisualProje\mobilyadb.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Veritabanından mobilya ve adet bilgilerini al
                    string query = "SELECT mobilya, adet FROM mobilyadb";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Grafik temizle
                            grafik.Series.Clear();

                            // ChartArea (grafik alanı) ayarla
                            if (grafik.ChartAreas.Count == 0)
                            {
                                grafik.ChartAreas.Add(new ChartArea("Default"));
                            }

                            // Verileri ayrı ayrı seriler olarak ekle
                            while (reader.Read())
                            {
                                // Veritabanından mobilya adı ve adet verilerini al
                                string mobilyaAdi = reader["mobilya"].ToString();
                                int adet = Convert.ToInt32(reader["adet"]);

                                // Her mobilya türü için ayrı bir seri oluştur
                                Series series = new Series
                                {
                                    Name = mobilyaAdi, // Seri adı mobilya türü olacak
                                    ChartType = SeriesChartType.Column, // Kolon tipi grafik
                                    IsValueShownAsLabel = true // Sütunların üstüne değerleri yazdır
                                };

                                // Seriye veri ekle (tek bir veri noktası)
                                series.Points.AddXY(mobilyaAdi, adet);

                                // Grafiğe seriyi ekle
                                grafik.Series.Add(series);
                            }

                            // X ekseni ayarları
                            grafik.ChartAreas[0].AxisX.Title = "Mobilya Türü";
                            grafik.ChartAreas[0].AxisX.Interval = 1; // Her bir mobilya türü için aralık
                            grafik.ChartAreas[0].AxisX.MajorGrid.Enabled = false; // X ekseninde grid çizgilerini kaldır

                            // Y ekseni ayarları
                            grafik.ChartAreas[0].AxisY.Title = "Adet";
                            grafik.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y ekseni grid çizgileri
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Grafik yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}