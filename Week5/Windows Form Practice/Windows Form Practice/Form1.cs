using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace H24121133_practice_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "1";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Double money = double.Parse(txtCapi.Text); //本金
            Double years = double.Parse(txtYear.Text); //年期
            Double yrate = double.Parse(txtRate.Text); //年利率
            Double total; //本利和
            total = money * Math.Pow((1 + yrate / 100), years);
            label4.Text = " accumulated amount = NT$ " + total.ToString("#,#.0") + " 元";
            label4.Text += "\n Total interest = NT$ " + (total - money).ToString("#,#.0") + "元";//總利息
        }


        private void txtCapi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Double money = double.Parse(txtCapi.Text); //本金
            Double years = double.Parse(txtYear.Text); //年期
            Double yrate = double.Parse(txtRate.Text); //年利率
            Double total; //本利和
            total = money * Math.Pow((1 + yrate / 100), years);
            label4.Text = " accumulated amount = NT$ " + total.ToString("#,#.0") + " 元";
            label4.Text += "\n Total interest = NT$ " + (total - money).ToString("#,#.0") + "元";//總利息
        }
    }
}