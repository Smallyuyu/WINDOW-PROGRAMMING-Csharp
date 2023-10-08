using System.Security.Cryptography.X509Certificates;

namespace H24121133_practice_3_1
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
            this.NAME = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.Label();
            this.B_Date = new System.Windows.Forms.Label();
            this.T_Date = new System.Windows.Forms.Label();
            this.Cat_Dog = new System.Windows.Forms.Label();
            this.NAME_TB = new System.Windows.Forms.TextBox();
            this.Gender_TB = new System.Windows.Forms.TextBox();
            this.B_DATE_TB = new System.Windows.Forms.TextBox();
            this.T_DATE_TB = new System.Windows.Forms.TextBox();
            this.CAT_DOG_TB = new System.Windows.Forms.TextBox();
            this.DATA_INPUT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NAME
            // 
            this.NAME.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NAME.Location = new System.Drawing.Point(120, 80);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(120, 30);
            this.NAME.TabIndex = 0;
            this.NAME.Text = "姓名";
            // 
            // Gender
            // 
            this.Gender.AutoSize = true;
            this.Gender.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Gender.Location = new System.Drawing.Point(120, 140);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(44, 22);
            this.Gender.TabIndex = 1;
            this.Gender.Text = "性別";
            this.Gender.Click += new System.EventHandler(this.label1_Click);
            // 
            // B_Date
            // 
            this.B_Date.AutoSize = true;
            this.B_Date.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.B_Date.Location = new System.Drawing.Point(120, 200);
            this.B_Date.Name = "B_Date";
            this.B_Date.Size = new System.Drawing.Size(95, 22);
            this.B_Date.TabIndex = 2;
            this.B_Date.Text = "出生年月日";
            // 
            // T_Date
            // 
            this.T_Date.AutoSize = true;
            this.T_Date.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.T_Date.Location = new System.Drawing.Point(120, 260);
            this.T_Date.Name = "T_Date";
            this.T_Date.Size = new System.Drawing.Size(78, 22);
            this.T_Date.TabIndex = 3;
            this.T_Date.Text = "今日日期";
            // 
            // Cat_Dog
            // 
            this.Cat_Dog.AutoSize = true;
            this.Cat_Dog.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cat_Dog.Location = new System.Drawing.Point(120, 320);
            this.Cat_Dog.Name = "Cat_Dog";
            this.Cat_Dog.Size = new System.Drawing.Size(95, 22);
            this.Cat_Dog.TabIndex = 4;
            this.Cat_Dog.Text = "貓派or狗派";
            // 
            // NAME_TB
            // 
            this.NAME_TB.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NAME_TB.Location = new System.Drawing.Point(246, 77);
            this.NAME_TB.Name = "NAME_TB";
            this.NAME_TB.Size = new System.Drawing.Size(300, 29);
            this.NAME_TB.TabIndex = 5;
            this.NAME_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NAME_TB.TextChanged += new System.EventHandler(this.NAME_TB_TextChanged);
            // 
            // Gender_TB
            // 
            this.Gender_TB.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Gender_TB.Location = new System.Drawing.Point(246, 137);
            this.Gender_TB.Name = "Gender_TB";
            this.Gender_TB.Size = new System.Drawing.Size(300, 29);
            this.Gender_TB.TabIndex = 6;
            this.Gender_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Gender_TB.TextChanged += new System.EventHandler(this.Gender_TB_TextChanged);
            // 
            // B_DATE_TB
            // 
            this.B_DATE_TB.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.B_DATE_TB.Location = new System.Drawing.Point(246, 193);
            this.B_DATE_TB.Name = "B_DATE_TB";
            this.B_DATE_TB.Size = new System.Drawing.Size(300, 29);
            this.B_DATE_TB.TabIndex = 7;
            this.B_DATE_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.B_DATE_TB.TextChanged += new System.EventHandler(this.B_DATE_TB_TextChanged);
            // 
            // T_DATE_TB
            // 
            this.T_DATE_TB.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.T_DATE_TB.Location = new System.Drawing.Point(246, 253);
            this.T_DATE_TB.Name = "T_DATE_TB";
            this.T_DATE_TB.Size = new System.Drawing.Size(300, 29);
            this.T_DATE_TB.TabIndex = 8;
            this.T_DATE_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.T_DATE_TB.TextChanged += new System.EventHandler(this.T_DATE_TB_TextChanged);
            // 
            // CAT_DOG_TB
            // 
            this.CAT_DOG_TB.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CAT_DOG_TB.Location = new System.Drawing.Point(246, 313);
            this.CAT_DOG_TB.Name = "CAT_DOG_TB";
            this.CAT_DOG_TB.Size = new System.Drawing.Size(300, 29);
            this.CAT_DOG_TB.TabIndex = 9;
            this.CAT_DOG_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CAT_DOG_TB.TextChanged += new System.EventHandler(this.CAT_DOG_TB_TextChanged);
            // 
            // DATA_INPUT
            // 
            this.DATA_INPUT.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DATA_INPUT.Location = new System.Drawing.Point(328, 20);
            this.DATA_INPUT.Name = "DATA_INPUT";
            this.DATA_INPUT.Size = new System.Drawing.Size(120, 30);
            this.DATA_INPUT.TabIndex = 10;
            this.DATA_INPUT.Text = "資料輸入";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(580, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "此欄位未填寫";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(580, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "此欄位未填寫";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(580, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "此欄位未填寫";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(580, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "此欄位未填寫";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(580, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "此欄位未填寫";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(246, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 30);
            this.button1.TabIndex = 16;
            this.button1.Text = "AI大神請告訴我答案吧";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DATA_INPUT);
            this.Controls.Add(this.CAT_DOG_TB);
            this.Controls.Add(this.T_DATE_TB);
            this.Controls.Add(this.B_DATE_TB);
            this.Controls.Add(this.Gender_TB);
            this.Controls.Add(this.NAME_TB);
            this.Controls.Add(this.Cat_Dog);
            this.Controls.Add(this.T_Date);
            this.Controls.Add(this.B_Date);
            this.Controls.Add(this.Gender);
            this.Controls.Add(this.NAME);
            this.Name = "Form1";
            this.Text = "AI算命系統";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NAME;
        private Label Gender;
        private Label B_Date;
        private Label T_Date;
        private Label Cat_Dog;
        public TextBox NAME_TB;
        public TextBox Gender_TB;
        public TextBox B_DATE_TB;
        public TextBox T_DATE_TB;
        public TextBox CAT_DOG_TB;
        private Label DATA_INPUT;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}