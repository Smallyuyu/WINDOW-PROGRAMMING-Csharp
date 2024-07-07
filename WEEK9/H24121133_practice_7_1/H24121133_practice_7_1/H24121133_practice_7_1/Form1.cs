using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace H24121133_practice_7_1
{
    public partial class Form1 : Form
    {
        public static bool closeflag = false;
        public static Label tmpl = new Label();
        public static int cur = 0;
        FileStream fcreate;
        bool fflag = false;
        FileInfo fi;
        Stream myStream = null;
        Stream cur_stream;
        string sfilename;
        bool flag = false;
        public static List<string> voc = new List<string>();
        public static List<string> ch = new List<string>();
        public static List<string> ob = new List<string>();
        public static List<bool> vis = new List<bool>();
        public Form1()
        {
            InitializeComponent();
            label4.Text = "";
            ini();
        }
        private void ini()
        {
            button1.Visible = false;
            textBox1.Visible= false;
            textBox2.Visible= false;
            comboBox1.Visible= false;
            label1.Visible= false;
            label2.Visible= false;
            label3.Visible= false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            新增單字ToolStripMenuItem.Text = "新增單字";
            搜尋單字ToolStripMenuItem.Text = "搜尋單字";
            只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
        }
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fflag = false;
            flag = false;
            voc.Clear();
            ch.Clear();
            ob.Clear();
            vis.Clear();
            label4.Text = "";
        }

        private void 檢視ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void sol(string s)
        {
            int cur = 0;
            List<string> t = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    t.Add(s.Substring(cur, i - cur));
                    cur = i + 1;
                }
            }
            t.Add(s.Substring(cur, s.Length - cur));
            voc.Add(t[0]);
            ch.Add(t[1]);
            ob.Add(t[2]);
            vis.Add(false);
            Update();
        }
        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fflag = true;
            voc.Clear();
            ch.Clear();
            ob.Clear();
            vis.Clear();
            label4.Text = "";
            flag = true;
            theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                using(myStream = theDialog.OpenFile())
                {
                    sfilename = theDialog.FileName;
                    using (StreamReader reader = new StreamReader(myStream))
                    {
                        var line = reader.ReadLine();

                        while (line != null)
                        {
                            if(line != "") sol(line);
                            line = reader.ReadLine();
                        }
                        reader.Close();
                    }
                    myStream.Close();
                    /*foreach (string line in File.ReadLines(sfilename))
                    {
                        sol(line);
                    }*/
                    //theDialog.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(新增單字ToolStripMenuItem.Text == "新增單字(v)" && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && comboBox1.SelectedIndex >= 0) 
            {
                voc.Add(textBox1.Text);
                ch.Add(textBox2.Text);
                ob.Add(comboBox1.GetItemText(comboBox1.SelectedItem));
                vis.Add(false);
                Update();
            }
            else if(搜尋單字ToolStripMenuItem.Text == "搜尋單字(v)")
            {
                List<bool> flagg= new List<bool> { false,false,false};
                label4.Text = "";
                if (checkBox1.Checked)
                {
                    flagg[0] = true;
                }
                if(checkBox2.Checked)
                {
                    flagg[1] = true;
                }
                if(checkBox3.Checked)
                {
                    flagg[2] = true;
                }
                for(int i = 0; i < voc.Count; i++)
                {
                    if (flagg[0])
                    {
                        if (voc[i] != textBox1.Text)
                        {
                            continue;
                        }
                    }
                    if (flagg[1])
                    {
                        if (ch[i] != textBox2.Text)
                        {
                            continue;
                        }
                    }
                    if (flagg[2])
                    {
                        if (ob[i] != comboBox1.GetItemText(comboBox1.SelectedItem))
                        {
                            continue;
                        }
                    }
                    label4.Text = label4.Text + voc[i] + " " + ch[i] + " " + ob[i] + Environment.NewLine;
                }
            }
        }
        private void Update()
        {
            label4.Text = "";
            for(int i = 0; i < voc.Count; i++)
            {
                label4.Text = label4.Text + voc[i] + " " + ch[i] + " " + ob[i] + Environment.NewLine;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void 新增單字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "新增";
            Update();
            if (新增單字ToolStripMenuItem.Text == "新增單字(v)")
            {
                ini();
            }
            else
            {
                ini();
                新增單字ToolStripMenuItem.Text = "新增單字(v)";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                comboBox1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
            }
        }

        private void 搜尋單字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "搜尋";
            if (搜尋單字ToolStripMenuItem.Text == "搜尋單字(v)")
            {
                ini();
                Update();
            }
            else
            {
                ini();
                搜尋單字ToolStripMenuItem.Text = "搜尋單字(v)";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                comboBox1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
            }
        }
        public static bool IsFileInUse(string fileName)
        {
            var inUse = true;
            if (!File.Exists(fileName)) return false;
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    inUse = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return inUse;
        }
        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                while (true)
                {
                    if (!IsFileInUse(sfilename)) break;
                }
                File.WriteAllText(sfilename, String.Empty);
                while (true)
                {
                    if (!IsFileInUse(sfilename)) break;
                }
                using (StreamWriter sw = new StreamWriter(sfilename))
                {
                    sw.WriteLine(label4.Text);
                    /*for (int i = 0; i < voc.Count; i++)
                    {
                        sw.WriteLine(voc[i] + " " + ch[i] + " " + ob[i]);
                    }*/
                }
                
            }
            else
            {
                save();
                flag = true;
            }
        }
        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fflag = false;
            save();
        }
        private void save()
        {
            Stream myStream2;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            //saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream2 = saveFileDialog1.OpenFile()) != null)
                {
                    sfilename = saveFileDialog1.FileName;
                    StreamWriter sr = new StreamWriter(myStream2);
                    sr.WriteLine(label4.Text);
                    /*for (int i = 0; i < voc.Count; i++)
                    {
                        sr.WriteLine(voc[i] + " " + ch[i] + " " + ob[i]);
                    }*/
                    sr.Close();
                    myStream2.Close();
                }
            }
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 單字測驗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (voc.Count > 0)
            {
                Visible = false;
                Update();
                ini();
                Form2 f2 = new Form2();
                //f2.Show();
                f2.ShowDialog();
                Visible = true;
            }
            else
            {
                MessageBox.Show("請先輸入單字!");
            }
        }
        private void 字型大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label4.Font = fontDialog1.Font;
            tmpl.Font = fontDialog1.Font;
            ini();
        }
        private void 清除標記ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < vis.Count; i++)
            {
                vis[i] = false;
            }
            ini();
            Update();
        }

        private void 只顯示標記單字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(只顯示標記單字ToolStripMenuItem.Text == "只顯示標記單字")
            {
                ini();
                只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字(v)";
                label4.Text = "";
                for(int i = 0; i < vis.Count; i++)
                {
                    if (vis[i]) label4.Text += voc[i] + " " + ch[i] + " " + ob[i] + Environment.NewLine;
                }
            }
            else
            {
                ini();
                Update();
            }
        }
    }
}