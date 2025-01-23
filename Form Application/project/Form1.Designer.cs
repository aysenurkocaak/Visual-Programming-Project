namespace VisualProje
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtad = new TextBox();
            txtsifre = new TextBox();
            btngiris = new Button();
            btnkayit = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PaleGoldenrod;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(114, 123);
            label1.Name = "label1";
            label1.Size = new Size(208, 28);
            label1.TabIndex = 0;
            label1.Text = "Enter your Username : ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PaleGoldenrod;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(125, 177);
            label2.Name = "label2";
            label2.Size = new Size(197, 28);
            label2.TabIndex = 1;
            label2.Text = "Enter your Password :";
            label2.Click += label2_Click;
            // 
            // txtad
            // 
            txtad.BackColor = SystemColors.Info;
            txtad.Location = new Point(347, 123);
            txtad.Name = "txtad";
            txtad.Size = new Size(256, 27);
            txtad.TabIndex = 2;
            // 
            // txtsifre
            // 
            txtsifre.BackColor = SystemColors.Info;
            txtsifre.Location = new Point(347, 177);
            txtsifre.Name = "txtsifre";
            txtsifre.Size = new Size(256, 27);
            txtsifre.TabIndex = 3;
            txtsifre.UseSystemPasswordChar = true;
            // 
            // btngiris
            // 
            btngiris.BackColor = Color.Indigo;
            btngiris.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btngiris.ForeColor = SystemColors.ControlLightLight;
            btngiris.Location = new Point(178, 258);
            btngiris.Name = "btngiris";
            btngiris.Size = new Size(169, 83);
            btngiris.TabIndex = 4;
            btngiris.Text = "Login ";
            btngiris.UseVisualStyleBackColor = false;
            btngiris.Click += button1_Click;
            // 
            // btnkayit
            // 
            btnkayit.BackColor = Color.Indigo;
            btnkayit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnkayit.ForeColor = SystemColors.ControlLightLight;
            btnkayit.Location = new Point(399, 258);
            btnkayit.Name = "btnkayit";
            btnkayit.Size = new Size(171, 83);
            btnkayit.TabIndex = 5;
            btnkayit.Text = "SignUp";
            btnkayit.UseVisualStyleBackColor = false;
            btnkayit.Click += btnkayit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Khaki;
            label3.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Indigo;
            label3.Location = new Point(178, 36);
            label3.Name = "label3";
            label3.Size = new Size(367, 45);
            label3.TabIndex = 6;
            label3.Text = "Welcome to Login Page ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnkayit);
            Controls.Add(btngiris);
            Controls.Add(txtsifre);
            Controls.Add(txtad);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtad;
        private TextBox txtsifre;
        private Button btngiris;
        private Button btnkayit;
        private Label label3;
    }
}