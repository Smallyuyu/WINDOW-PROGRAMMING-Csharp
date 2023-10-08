using System.Numerics;
using static student.Program;

namespace student
{
    class Program {
        public struct subject
        {
            public string label;
            public string new_rank, old_rank;
            public int credit;
            public double new_gpa, old_gpa;
            public int score;
            public subject(string label2,string new_rank2,string old_rank2,int credit2,double new_gpa2,double old_gpa2,int score2)
            {
                this.label = label2;
                this.new_rank = new_rank2;
                this.old_rank = old_rank2;
                this.credit = credit2;
                this.new_gpa = new_gpa2;
                this.old_gpa = old_gpa2;
                this.score = score2;
            }
            public static bool operator ==(subject s1, subject s2)
            {
                if (s1.label == s2.label)
                    return true;
                return false;
            }

            public static bool operator !=(subject s1, subject s2)
            {
                if (s1.label == s2.label)
                    return false;
                return true;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is subject && Equals((subject)obj);
            }

            public bool Equals(subject other)
            {
                return this.label == other.label;
            }

            public override int GetHashCode()
            {
                return this.score;
            }
        }
        public class SubjectComparer : IComparer<subject>
        {
            public int Compare(subject x, subject y)
            {
                if (x.score > y.score) return 1;
                return 0;
            }
        }
        public static void print_menu()
        {
            Console.WriteLine("## 成績計算器 ##");
            Console.WriteLine("1. 新增科目(create)");
            Console.WriteLine("2. 刪除科目(delete)");
            Console.WriteLine("3. 更新科目(update)");
            Console.WriteLine("4. 列印成績單(print)");
            Console.WriteLine("5. 退出選單(exit)");
            Console.Write("輸入要執行的指令操作: ");
        }
        public static string new_rank(int score)
        {
            if (score >= 90) return "A+";
            else if (score >= 85) return "A";
            else if (score >= 80) return "A-";
            else if (score >= 77) return "B+";
            else if (score >= 73) return "B";
            else if (score >= 70) return "B-";
            else if (score >= 67) return "C+";
            else if (score >= 63) return "C";
            else if (score >= 60) return "C-";
            return "F";
        }
        public static string old_rank(int score)
        {
            if (score >= 80) return "A";
            else if (score >= 70) return "B";
            else if (score >= 60) return "C";
            else if (score >= 50) return "D";
            return "E";
        }
        public static double new_gpa(int score)
        {
            if (score >= 90) return 4.3;
            else if (score >= 85) return 4.0;
            else if (score >= 80) return 3.7;
            else if (score >= 77) return 3.3;
            else if (score >= 73) return 3.0;
            else if (score >= 70) return 2.7;
            else if (score >= 67) return 2.3;
            else if (score >= 63) return 2.0;
            else if (score >= 60) return 1.7;
            return 0;
        }
        public static double old_gpa(int score)
        {
            if(score >= 80) return 4.0;
            else if (score >= 70) return 3.0;
            else if (score >= 60) return 2.0;
            else if (score >= 50) return 1.0;
            return 0;
        }
        static void Main(string[] args) {
            int index = 0;
            List<subject> subject_list = new List<subject>();
            SortedDictionary<string, int> label_list = new SortedDictionary<string, int>();
            string op,label_;
            int credit_,score_;
            while (true)
            {
                print_menu();
                string b = Console.ReadLine();
                string[] sArray = b.Split(' ');
                op = sArray[0];
                subject tmp;
                if (op == "create")
                {
                    label_ = sArray[1];
                    score_ = int.Parse(sArray[2]);
                    credit_ = int.Parse(sArray[3]);
                    if(score_ < 0 || score_ > 100)
                    {
                        Console.WriteLine("成績分數異常! 請重新輸入!");
                        continue;
                    }
                    if(credit_ < 0 || credit_ > 10)
                    {
                        Console.WriteLine("學分數異常! 請重新輸入!");
                        continue;
                    }
                    tmp.label = label_;
                    tmp.credit = credit_;
                    tmp.score = score_;
                    tmp.new_rank = new_rank(score_);
                    tmp.old_rank = old_rank(score_);
                    tmp.new_gpa = new_gpa(score_);
                    tmp.old_gpa = old_gpa(score_);
                    if (label_list.ContainsKey(label_))
                    {
                        Console.WriteLine("科目已存在");
                    }
                    else
                    {
                        label_list.Add(label_, score_);
                        subject_list.Add(tmp);
                        Console.WriteLine("科目已新增");
                    }
                }
                else if(op == "delete")
                {
                    label_ = sArray[1];
                    if (label_list.ContainsKey(label_))
                    {
                        foreach (subject kvp in subject_list)
                        {
                            if(kvp.label == label_)
                            {
                                tmp = kvp;
                                subject_list.Remove(tmp);
                                break;
                            }
                        }
                        label_list.Remove(label_);
                        Console.WriteLine("科目已刪除");
                    }
                    else
                    {
                        Console.WriteLine("科目不存在");
                    }
                }
                else if(op == "update")
                {
                    label_ = sArray[1];
                    score_ = int.Parse(sArray[2]);
                    credit_ = int.Parse(sArray[3]);
                    if (score_ < 0 || score_ > 100)
                    {
                        Console.WriteLine("成績分數異常! 請重新輸入!");
                        continue;
                    }
                    if (credit_ < 0 || credit_ > 10)
                    {
                        Console.WriteLine("學分數異常! 請重新輸入!");
                        continue;
                    }
                    if (label_list.ContainsKey(label_))
                    {
                        foreach (subject kvp in subject_list)
                        {
                            if (kvp.label == label_)
                            {
                                tmp = kvp;
                                subject_list.Remove(tmp);
                                break;
                            }
                        }
                        label_list.Remove(label_);
                        tmp.label = label_;
                        tmp.credit = credit_;
                        tmp.score = score_;
                        tmp.new_rank = new_rank(score_);
                        tmp.old_rank = old_rank(score_);
                        tmp.new_gpa = new_gpa(score_);
                        tmp.old_gpa = old_gpa(score_);
                        subject_list.Add(tmp);
                        Console.WriteLine("科目已更新");
                    }
                    else
                    {
                        Console.WriteLine("科目不存在");
                    }
                }
                else if(op == "print")
                {
                    for(int i = 0; i < subject_list.Count; i++)
                    {
                        for(int j = i + 1; j < subject_list.Count; j++)
                        {
                            if (subject_list[i].score < subject_list[j].score)
                            {
                                tmp = subject_list[i];
                                subject_list[i] = subject_list[j];
                                subject_list[j] = tmp;
                            }
                        }
                    }
                    Console.WriteLine("我的成績單");
                    Console.WriteLine("編號  科目代碼   分數   等第    學分數");
                    int cur = 0;
                    double score_sum = 0;
                    double old_gpa_sum = 0;
                    double new_gpa_sum = 0;
                    double r_credit = 0;
                    double a_credit = 0;
                    foreach (subject kvp in subject_list)
                    {
                        cur++;
                        Console.Write(cur);
                        Console.WriteLine("      " + kvp.label + "     " + kvp.score + "     " + kvp.old_rank + "        " + kvp.credit);
                        score_sum += kvp.score * kvp.credit;
                        old_gpa_sum += kvp.old_gpa * kvp.credit;
                        new_gpa_sum += kvp.new_gpa * kvp.credit;
                        if(kvp.score >= 60) r_credit += kvp.credit;
                        a_credit += kvp.credit;
                    }
                    Console.Write("總平均: ");
                    Console.WriteLine(Math.Round((score_sum / a_credit), 2));
                    Console.Write("GPA: ");
                    Console.Write(Math.Round(old_gpa_sum / a_credit, 1));
                    Console.Write("/4.0 (舊制), ");
                    Console.Write(Math.Round(new_gpa_sum / a_credit, 1));
                    Console.WriteLine("/4.3 (新制)");
                    Console.Write("實拿學分數/總學分數: ");
                    Console.WriteLine(r_credit + "/" + a_credit);
                }
                else if(op == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("指令格式不符! 請重新輸入!");
                }
                Console.WriteLine(" ");
            }
        }
    }
}