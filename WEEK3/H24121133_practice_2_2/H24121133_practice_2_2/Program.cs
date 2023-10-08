using System;
using System.Collections.Specialized;
using System.Runtime.Intrinsics.X86;

namespace shop
{
    class Program
    {
        public static void Print_END_map(char[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            Console.Write(" ");
            for (int i = 0; i < m; i++)
            {
                Console.Write(" " + (char)('A' + i));
            }
            Console.WriteLine(" ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(i);
                for (int j = 0; j < m; j++)
                {
                    Console.Write(" " + arr[i, j]);
                }
                Console.WriteLine(" ");
            }
        }
        public static void Print_map(char[,] arr, int[,] vis)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            Console.Write(" ");
            for(int i = 0; i < m; i++)
            {
                Console.Write(" " + (char)('A' + i));
            }
            Console.WriteLine(" ");
            for(int i = 0; i < n; i++)
            {
                Console.Write(i);
                for(int j = 0; j < m; j++)
                {
                    if (vis[i, j] == 1) Console.Write(" " + arr[i, j]);
                    else Console.Write(" -");
                }
                Console.WriteLine(" ");
            }
        }
        public static int check_(char[,] arr ,int x,int y)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            List<int> dx = new List<int>(){ -1, -1, -1, 0, 0, 0, 1, 1, 1 };
            List<int> dy = new List<int>(){ -1, 0, 1, -1, 0, 1, -1, 0, 1 };
            int tx, ty,cnt = 0;
            for(int i = 0; i < 9; i++)
            {
                tx = x + dx[i]; ty = y + dy[i];
                if (tx >= n || ty >= m || tx < 0 || ty < 0) continue;
                if (arr[tx,ty] == 'X') cnt++;
            }
            return cnt + 48;

        }
        static void Main(string[] args)
        {
            int n, m;
            int num;
            string s;
            Console.WriteLine("設定遊戲參考");
            Console.Write("輸入空間的大小: " );
            s = Console.ReadLine();
            List<string> t = new List<string>() { "",""};
            int cur = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    cur++;
                }
                else
                {
                    t[cur] = t[cur] + s[i];
                }
            }
            n = int.Parse(t[0]);
            m = int.Parse(t[1]);
            Console.Write("輸入鬼的數量: ");
            num = int.Parse(Console.ReadLine());
            Console.Clear();
            int x;
            char c;
            bool flag;
            char[,] arr = new char[n, m];
            int[,] vis = new int[n, m];
            List<int> exist_ = new List<int>();
            cur = 0;
            int All_sum = n * m;

            int y,win_cnt = 0;
            bool flag2 = false;
            while (true)
            {
                if(num >= All_sum)
                {
                    Console.WriteLine("遊戲參數錯誤!");
                    break;
                }
                Console.Clear();
                Print_map(arr,vis);
                Console.Write("輸入要查看的位置: ");
                s = Console.ReadLine();
                t[0] = ""; t[1] = "";
                cur = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ',')
                    {
                        cur++;
                    }
                    else
                    {
                        t[cur] = t[cur] + s[i];
                    }
                }
                x = int.Parse(t[0]);
                s = t[1];
                y = (int)(s[0] - 'A');
                flag = false;
                if (x < 0 || x >= n) flag = true;
                if (0 > y || 26 <= y) flag = true;
                if (vis[x, y] == 1) flag = true;
                //Print_END_map(arr);
                while (flag)
                {
                    Console.WriteLine("無效的輸入,請再試一次");
                    Console.Write("輸入要查看的位置: ");
                    s = Console.ReadLine();
                    t[0] = ""; t[1] = "";
                    cur = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == ',')
                        {
                            cur++;
                        }
                        else
                        {
                            t[cur] = t[cur] + s[i];
                        }
                    }
                    x = int.Parse(t[0]);
                    s = t[1];
                    y = (int)(s[0] - 'A');
                    if (x > 0 && x < n && 0 <= y && 26 > y && (vis[x,y] == 0)) flag = false;
                }
                if (!flag2)
                {
                    flag2 = true;
                    Random ran = new Random();
                    int ranNum;
                    //Random Ghost Position
                    while (cur <= num)
                    {
                        ranNum = ran.Next(0, All_sum - 1);
                        if (exist_.Contains(ranNum)) cur--;
                        else if (ranNum / m == x && ranNum % m == y) cur--;
                        else exist_.Add(ranNum);
                        cur++;
                    }
                    for (int i = 0; i < num; i++)
                    {
                        arr[(exist_[i] / m), (exist_[i] % m)] = 'X';
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            vis[i, j] = 0;
                            if (arr[i, j] == 'X') continue;
                            arr[i, j] = (char)check_(arr, i, j);
                        }
                    }
                    win_cnt++;
                    vis[x, y] = 1;
                }
                else if (arr[x,y] == 'X')
                {
                    Console.Clear();
                    Print_END_map(arr);
                    Console.WriteLine("遊戲結束! 你被鬼抓到了");
                    break;
                }
                else
                {
                    win_cnt++;
                    vis[x, y] = 1;
                    if(win_cnt == (All_sum - num))
                    {
                        Console.Clear();
                        Print_map(arr, vis);
                        Console.WriteLine("遊戲結束! 你成功躲避所有的鬼了");
                        break;
                    }
                }
            }
        }
    }
}