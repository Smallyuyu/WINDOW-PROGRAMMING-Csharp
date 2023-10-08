using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace H24121133
{
    class Program
    {
        public static void Clear_(int cur_flag,int last_flag)
        {
            if (cur_flag != last_flag && last_flag != -1)
            {
                Console.Clear();
            }
        }

        public struct member
        {
            public member(string name_,string department_,string ID_)
            {
                name = name_;
                department = department_;
                ID = ID_;
                level = 1;
            }
            public void Register(string name_,string department_,string ID_)
            {
                member m1 = new member(name_, department_, ID_);
                for(int i = 0; i < list.Count; i++)
                {
                    if (Compare_(m1, list[i])){
                        member m2 = list[i];
                        m2.level = list[i].level + 1;
                        if (m2.level == 2)
                        {
                            Console.WriteLine("已晉升資深社員");
                        }
                        else if (m2.level == 3)
                        {
                            Console.WriteLine("已晉升永久社員");
                        }
                        else
                        {
                            Console.WriteLine("已經是永久社員了喔");
                        }
                        list[i] = m2;
                        return;
                    }
                }
                list.Add(m1);
                Console.WriteLine("歡迎新社員!!");
            }
            public void Print_Member(member m1)
            {
                Console.WriteLine($"{m1.name.PadRight(8)} {m1.department.PadRight(8)} {m1.ID.PadRight(8)} {levels[(m1.level > 3) ? 3 : m1.level].PadRight(8)} {m1.title.PadRight(8)}");
            }
            public void Search_Name(string Name_)
            {
                bool flag = false;
                foreach(var m1 in list)
                {
                    if(Name_ == m1.name)
                    {
                        Print_Member(m1);
                        flag = true;
                    }
                }
                if (!flag) Console.WriteLine("          找不到這個人ㄟ");
            }
            public void Search_Department(string Department_)
            {
                bool flag = false;
                foreach (var m1 in list)
                {
                    if (Department_ == m1.department)
                    {
                        Print_Member(m1);
                        flag = true;
                    }
                }
                if (!flag) Console.WriteLine("          找不到這個系的人ㄟ");
            }
            public void Search_ID(string ID_)
            {
                bool flag = false;
                foreach (var m1 in list)
                {
                    if (ID_ == m1.ID)
                    {
                        Print_Member(m1);
                        flag = true;
                    }
                }
                if (!flag) Console.WriteLine("          找不到這個學號的人ㄟ");
            }
            public void Search_Level(string Level_)
            {
                bool flag = false;
                foreach (var m1 in list)
                {
                    if (Level_ == levels[(m1.level > 3) ? 3 : m1.level])
                    {
                        Print_Member(m1);
                        flag = true;
                    }
                }
                if (!flag) Console.WriteLine("          找不到這個等級的人ㄟ");
            }
            public void Search_Title(string Title_)
            {
                bool flag = false;
                foreach (var m1 in list)
                {
                    if (Title_ == m1.title)
                    {
                        Print_Member(m1);
                        flag = true;
                    }
                }
                if (!flag) Console.WriteLine("          找不到這個職務的人ㄟ");
            }
            public void Entitle(string name_,string department_,string ID_,string title_)
            {
                member m1 = new member(name_, department_, ID_);
                for (int i = 0; i < list.Count; i++)
                {
                    if (Compare_(m1, list[i]))
                    {
                        member m2 = list[i];
                        if (title_.Contains("社長"))
                        {
                            Console.WriteLine("          我們的社長只有阿明一個人，你不要想篡位!");
                        }
                        else
                        {
                            m2.title = title_;
                            list[i] = m2;
                            Console.WriteLine("          " + name_ + "已晉升為" + title_);
                        }
                        return;
                    }
                }
                Console.WriteLine("          找不到這個人ㄟ");
            }
            public void Check()
            {
                Console.WriteLine("----------------------------------------------------------");
                foreach(var m1 in list)
                {
                    Print_Member(m1);
                }
                Console.WriteLine("----------------------------------------------------------");
            }
            public void Add_level()
            {
                level++;
            }
            public void Start()
            {
                Console.WriteLine("----------------------------###   社員資料登記   ###----------------------------");
                Console.WriteLine($"{"新增社員資訊:".PadRight(10)} {"register".PadRight(12)} {"name".PadRight(14)} {"department".PadRight(15)} {"ID"}");
                Console.WriteLine($"{"以特定屬性查詢:".PadRight(9)} {"search".PadRight(12)} {"name".PadRight(14)} {"tag".PadRight(11)} {"Want_search_string"}");
                Console.WriteLine($"{"授予社員職位:".PadRight(10)} {"entitle".PadRight(12)} {"name".PadRight(14)} {"department".PadRight(15)} {"ID".PadRight(16)} {"That_title"}");
                Console.WriteLine($"{"所有社員列表:".PadRight(10)} {"check".PadRight(12)}");
                Console.WriteLine($"{"指令格式列表:".PadRight(10)} {"help".PadRight(12)}");
                Console.WriteLine($"{"離開此程式:".PadRight(12)}" + "exit");
            }
            public void Help()
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"{"新增社員資訊:".PadRight(10)} {"register".PadRight(12)} {"name".PadRight(14)} {"department".PadRight(15)} {"ID"}");
                Console.WriteLine($"{"以特定屬性查詢:".PadRight(9)} {"search".PadRight(12)} {"name".PadRight(14)} {"tag".PadRight(11)} {"Want_search_string"}");
                Console.WriteLine($"{"授予社員職位:".PadRight(10)} {"entitle".PadRight(12)} {"name".PadRight(14)} {"department".PadRight(15)} {"ID".PadRight(16)} {"That_title"}");
                Console.WriteLine($"{"所有社員列表:".PadRight(10)} {"check".PadRight(12)}");
                Console.WriteLine($"{"指令格式列表:".PadRight(10)} {"help".PadRight(12)}");
                Console.WriteLine($"{"離開此程式:".PadRight(12)}" + "exit");
                Console.WriteLine("----------------------------------------------------------");
            }
            public bool Compare_(member m1,member m2)
            {
                if(m1.name == m2.name && m1.department == m2.department && m1.ID == m2.ID)
                {
                    return true;
                }
                return false;
            }
            private List<member> list = new List<member>();
            private List<string> levels = new List<string>() { "無","萌新社員","資深社員","永久社員" };
            private string name = "";
            private string department = "";
            private string ID = "";
            private int level = 0;
            private string title = "無";
        }
        static void Main(string[] args)
        {
            member m1 = new member("","","");
            m1.Start();
            string op,name ,department,ID,level,title;
            List<string> mem = new List<string>(){" "," "," "," "};
            int last_flag = -1, cur_flag = -1;
            while (true)
            {
                op = Console.ReadLine();
                op = op + " ";
                if (op.Contains("register"))
                {
                    cur_flag = 1;
                    Clear_(cur_flag, last_flag);
                    int cur = 9;
                    int cnt = 0;
                    for(int i = 9; i < op.Length; i++)
                    {
                        if (op[i] == ' ')
                        {
                            mem[cnt++] = op.Substring(cur, i - cur);
                            cur = i + 1;
                        }
                    }
                    m1.Register(mem[0], mem[1], mem[2]);
                    last_flag = 1;
                }
                else if (op.Contains("search"))
                {
                    cur_flag = 2;
                    Clear_(cur_flag, last_flag);
                    if (op.Contains("name"))
                    {
                        name = op.Substring(12, op.Length - 13);
                        m1.Search_Name(name);
                    }
                    else if (op.Contains("department"))
                    {
                        department = op.Substring(18, op.Length - 19);
                        m1.Search_Department(department);
                    }
                    else if (op.Contains("ID"))
                    {
                        ID = op.Substring(10, op.Length - 11);
                        m1.Search_ID(ID);
                    }
                    else if (op.Contains("level"))
                    {
                        level = op.Substring(13, op.Length - 14);
                        m1.Search_Level(level);
                    }
                    else if (op.Contains("title"))
                    {
                        title = op.Substring(13, op.Length - 14);
                        m1.Search_Title(title);
                    }
                    else
                    {
                        Console.WriteLine("          不存在這個tag，有疑慮請打help");
                    }
                    last_flag = 2;
                }
                else if (op.Contains("entitle"))
                {
                    cur_flag = 3;
                    Clear_(cur_flag, last_flag);
                    int cur = 8;
                    int cnt = 0;
                    for (int i = 8; i < op.Length; i++)
                    {
                        if (op[i] == ' ')
                        {
                            mem[cnt++] = op.Substring(cur, i - cur);
                            cur = i + 1;
                        }
                    }
                    m1.Entitle(mem[0], mem[1], mem[2], mem[3]);
                    last_flag = 3;
                }
                else if (op.Contains("check"))
                {
                    cur_flag = 4;
                    Clear_(cur_flag, last_flag);
                    m1.Check();
                    last_flag = 4;
                }
                else if (op.Contains("help"))
                {
                    cur_flag = 5;
                    Clear_(cur_flag, last_flag);
                    m1.Help();
                    last_flag = 5;
                }
                else if (op.Contains("exit"))
                {
                    break;
                }
                else
                {
                    cur_flag = 6;
                    Clear_(cur_flag, last_flag);
                    Console.WriteLine("          不存在這個功能，有疑慮請打help");
                    last_flag = 6;
                }
            }
        }
    }
}