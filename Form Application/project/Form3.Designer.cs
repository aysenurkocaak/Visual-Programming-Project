namespace VisualProje
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            grafik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btngeri = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)grafik).BeginInit();
            SuspendLayout();
            // 
            // grafik
            // 
            grafik.BackColor = Color.SkyBlue;
            chartArea2.Name = "ChartArea1";
            grafik.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            grafik.Legends.Add(legend2);
            grafik.Location = new Point(248, 95);
            grafik.Name = "grafik";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            grafik.Series.Add(series2);
            grafik.Size = new Size(644, 438);
            grafik.TabIndex = 0;
            grafik.Text = "chart1";
            grafik.Click += grafik_Click;
            // 
            // btngeri
            // 
            btngeri.BackColor = Color.RoyalBlue;
            btngeri.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btngeri.Location = new Point(41, 253);
            btngeri.Name = "btngeri";
            btngeri.Size = new Size(169, 70);
            btngeri.TabIndex = 1;
            btngeri.Text = "Go Back ";
            btngeri.UseVisualStyleBackColor = false;
            btngeri.Click += btngeri_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(549, 45);
            label1.TabIndex = 2;
            label1.Tag = "";
            label1.Text = "Welcome to the Graph Creation Page";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(929, 563);
            Controls.Add(label1);
            Controls.Add(btngeri);
            Controls.Add(grafik);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)grafik).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafik;
        private Button btngeri;
        private Label label1;
    }
}