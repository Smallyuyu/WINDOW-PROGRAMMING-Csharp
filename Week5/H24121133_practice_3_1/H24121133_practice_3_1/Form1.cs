namespace H24121133_practice_3_1
{
    public partial class Form1 : Form
    {
        bool flag1 = false, flag2 = false, flag3 = false, flag4 = false, flag5 = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void NAME_TB_TextChanged(object sender, EventArgs e)
        {
            if(NAME_TB.Text == "")
            {
                label1.Text = "����쥼��g";
                flag1 = false;
            }
            else
            {
                label1.Text = "";
                flag1 = true;
            }
        }
        private void Gender_TB_TextChanged(object sender, EventArgs e)
        {
            if (Gender_TB.Text == "")
            {
                label2.Text = "����쥼��g";
                flag2 = false;
            }
            else if(Gender_TB.Text == "�k" || Gender_TB.Text == "�k")
            {
                label2.Text = "";
                flag2 = true;
            }
            else
            {
                label2.Text = "��J�����kor�k";
                flag2 = false;
            }
        }
        private void B_DATE_TB_TextChanged(object sender, EventArgs e)
        {
            bool tmpflag = false;
            if (B_DATE_TB.Text == "")
            {
                flag3 = false;
                label3.Text = "����쥼��g";
            }
            else if (B_DATE_TB.Text.Length == 10 && B_DATE_TB.Text[4] == '/' && B_DATE_TB.Text[7] == '/') 
            {
                flag3 = true;
                tmpflag = true;
                label3.Text = "";
                for(int i = 0; i < 10; i++)
                {
                    if (i == 4 || i == 7) continue;
                    if (!(B_DATE_TB.Text[i] >= '0' && B_DATE_TB.Text[i] <= '9'))
                    {
                        tmpflag = false;
                    }
                }
                if (!tmpflag)
                {
                    flag3 = false;
                    label3.Text = "�榡���~\n(�d��:2023/10/06)";
                }
            }
            else
            {
                flag3 = false;
                label3.Text = "�榡���~\n(�d��:2023/10/06)";
            }
        }
        private void T_DATE_TB_TextChanged(object sender, EventArgs e)
        {
            if (T_DATE_TB.Text == "")
            {
                flag4 = false;
                label4.Text = "����쥼��g";
            }
            else if(T_DATE_TB.Text.Length != 10)
            {
                flag4 = false;
                label4.Text = "�榡���~\n(�d��:2023/10/06)";
            }
            else if(T_DATE_TB.Text == DateTime.Now.ToString("yyyy/MM/dd"))
            {
                flag4 = true;
                label4.Text = "";
            }
            else
            {
                flag4 = false;
                label4.Text = "������~";
            }
        }
        private void CAT_DOG_TB_TextChanged(object sender, EventArgs e)
        {
            if (CAT_DOG_TB.Text == "")
            {
                flag5 = false;
                label5.Text = "����쥼��g";
            }
            else if(CAT_DOG_TB.Text == "��" || CAT_DOG_TB.Text == "��")
            {
                flag5 = true;
                label5.Text = "";
            }
            else
            {
                flag5 = false;
                label5.Text = "��J������or��";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag1 == true && flag2 == true && flag3 == true && flag4 == true && flag5 == true )
            {
                Form2 F2 = new Form2(NAME_TB.Text,Gender_TB.Text,B_DATE_TB.Text,T_DATE_TB.Text,CAT_DOG_TB.Text);
                this.Visible = false;
                F2.Visible = true;
            }
        }
    }
}