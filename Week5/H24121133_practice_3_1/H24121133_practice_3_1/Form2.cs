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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string Name,string Gender,string B_Date,string T_Date,string Cat_Dog)
        {
            InitializeComponent();
            NAME_2.Text = Name;
            Gender_2.Text = Gender;
            B_DATE_2.Text = B_Date;
            T_DATE_2.Text = T_Date;
            Cat_Dog_2.Text = Cat_Dog;
            String[] analysis = { "桃花運大漲", "家庭遭逢變故", "事業平步青雲，有升官可能", "事業起伏大", "親人病情好轉", "被財神眷顧", "近期一帆風順" };

            String[] suggest = { "少做壞事，夜路走多了總匯三明治",
                     "保持謙虛，一山還有一山高，雞蛋還有雞蛋糕",
                     "善待他人，不要任意嘲笑別人，除非你忍不住",
                     "早點睡覺，不要仗著自己長得醜，就任意熬夜",
                     "小心小人，可謂浮雲能蔽日，輕舟已過萬重山",
                     "不要偷懶，你在睡覺的時候，美國人還在上班阿",
                     "健康第一，定期身體檢查並謹記醫生怎麼說，doctor!",
                     "穩定情緒，今天不開心沒關係，反正明天也不會開心"};
            Random rnd = new Random();
            Fate.Text = "運勢:" + analysis[rnd.Next(analysis.Length)];
            Suggest.Text = "建議:" + suggest[rnd.Next(suggest.Length)];
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            this.Visible = false;
            F1.Visible = true;
        }
    }
}
