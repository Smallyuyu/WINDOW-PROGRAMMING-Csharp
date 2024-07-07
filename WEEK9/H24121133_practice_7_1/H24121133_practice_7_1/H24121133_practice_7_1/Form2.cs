using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H24121133_practice_7_1
{
    public partial class Form2 : Form
    {
        int state, n = Form1.vis.Count(),cur;
        Random rnd = new Random();
        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(state == 1) Form1.vis[cur] = checkBox1.Checked;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.closeflag = false;
            label1.Font = Form1.tmpl.Font;
            label2.Font = Form1.tmpl.Font;
            label3.Font = Form1.tmpl.Font;
            Update2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update2();
        }
        private void Form2_FormClosed(object sender,EventArgs e)
        {

        }
        private void Update(int i)
        {
            label1.Text = "單字:" + Form1.voc[i];
            label2.Text = "中文:" + Form1.ch[i];
            label3.Text = "詞性:" + Form1.ob[i];
        }
        private void Update2()
        {
            state = 0;
            Update(cur = rnd.Next(0, n));
            label2.Visible = false;
            label3.Visible = false;
            checkBox1.Checked = Form1.vis[cur];
            state = 1;
        }
    }
}
