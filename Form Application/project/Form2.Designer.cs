namespace VisualProje
{
    partial class Form2
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
            btnekle = new Button();
            label1 = new Label();
            label2 = new Label();
            btngrafik = new Button();
            txtmob = new TextBox();
            txtsayi = new TextBox();
            btncikart = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnekle
            // 
            btnekle.BackColor = Color.SlateBlue;
            btnekle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnekle.Location = new Point(594, 153);
            btnekle.Name = "btnekle";
            btnekle.Size = new Size(174, 85);
            btnekle.TabIndex = 0;
            btnekle.Text = "ADD ";
            btnekle.UseVisualStyleBackColor = false;
            btnekle.Click += btnekle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Orange;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(29, 172);
            label1.Name = "label1";
            label1.Size = new Size(255, 28);
            label1.TabIndex = 1;
            label1.Text = "Enter the type of Furniture : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Orange;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(99, 237);
            label2.Name = "label2";
            label2.Size = new Size(185, 28);
            label2.TabIndex = 2;
            label2.Text = "Enter the Quantity : ";
            // 
            // btngrafik
            // 
            btngrafik.BackColor = Color.SlateBlue;
            btngrafik.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btngrafik.Location = new Point(128, 315);
            btngrafik.Name = "btngrafik";
            btngrafik.Size = new Size(381, 102);
            btngrafik.TabIndex = 3;
            btngrafik.Text = "CREATE A CHART ";
            btngrafik.UseVisualStyleBackColor = false;
            btngrafik.Click += btngrafik_Click;
            // 
            // txtmob
            // 
            txtmob.BackColor = Color.LavenderBlush;
            txtmob.Location = new Point(304, 172);
            txtmob.Name = "txtmob";
            txtmob.Size = new Size(249, 27);
            txtmob.TabIndex = 4;
            // 
            // txtsayi
            // 
            txtsayi.BackColor = Color.LavenderBlush;
            txtsayi.Location = new Point(304, 241);
            txtsayi.Name = "txtsayi";
            txtsayi.Size = new Size(249, 27);
            txtsayi.TabIndex = 5;
            // 
            // btncikart
            // 
            btncikart.BackColor = Color.SlateBlue;
            btncikart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btncikart.Location = new Point(594, 287);
            btncikart.Name = "btncikart";
            btncikart.Size = new Size(174, 88);
            btncikart.TabIndex = 6;
            btncikart.Text = "REMOVE";
            btncikart.UseVisualStyleBackColor = false;
            btncikart.Click += btncikart_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.NavajoWhite;
            label3.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(68, 47);
            label3.Name = "label3";
            label3.Size = new Size(503, 45);
            label3.TabIndex = 7;
            label3.Text = "Welcome to the Transaction Page ";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btncikart);
            Controls.Add(txtsayi);
            Controls.Add(txtmob);
            Controls.Add(btngrafik);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnekle);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnekle;
        private Label label1;
        private Label label2;
        private Button btngrafik;
        private TextBox txtmob;
        private TextBox txtsayi;
        private Button btncikart;
        private Label label3;
    }
}