using System.Data.SqlTypes;
using System.Numerics;

namespace shop
{
    class Program
    {
        struct goods
        {
            public string name;
            public int price;
            public int nums;
        }
        static void Main(string[] args)
        {
            int option = 0, goods_option = 0, goods_nums = 0;
            List<int> stock = new List<int>();
            stock.Add(1); stock.Add(2); stock.Add(1);
            List<double> money = new List<double>();
            money.Add(1);  money.Add(1); money.Add(0.031); money.Add(0.23); money.Add(4.59);

            List<string> money_label = new List<string>();
            money_label.Add("TWD");  money_label.Add("TWD"); money_label.Add("USD"); money_label.Add("CNY"); money_label.Add("JPY");

            List<goods> car = new List<goods>();
            goods tmp;
            tmp.name = "潛水相機防丟繩"; tmp.price = 199; tmp.nums = 0;
            car.Add(tmp);
            tmp.name = "潛水配重帶"; tmp.price = 460; tmp.nums = 0;
            car.Add(tmp);
            tmp.name = "潛水作業指北針"; tmp.price = 1100; tmp.nums = 0;
            car.Add(tmp);
            int cur_money = 0;
            while (true)
            {
                Console.WriteLine("(1)商品列表 (2)新增至購物車 (3)自購物車刪除 (4)查看購物車 (5)結帳 (6)轉換幣值 (7)退出網站");
                Console.Write("輸入數字選擇功能： ");
                option = int.Parse(Console.ReadLine());
                if (option > 7 || option < 1)
                {
                    Console.WriteLine("輸入錯誤！請重新輸入！\n");
                    continue;
                }
                if (option == 1)
                {
                    Console.WriteLine("列表:");
                    Console.WriteLine("商品名稱 商品單價");
                    Console.WriteLine("1.潛水相機防丟繩 ("+ money_label[cur_money] + ")" + car[0].price * money[cur_money]);
                    Console.WriteLine("2.潛水配重帶 (" + money_label[cur_money] + ")" + car[1].price * money[cur_money]);
                    Console.WriteLine("3.潛水作業指北針 (" + money_label[cur_money] + ")" + car[2].price * money[cur_money] + "\n");
                }
                else if (option == 2)
                {
                    Console.WriteLine("(1)潛水相機防丟繩 (2)潛水配重帶 (3)潛水作業指北針");
                    Console.Write("輸入數字選擇商品： ");

                    goods_option = int.Parse(Console.ReadLine());
                    if (goods_option > 3 || goods_option < 1)
                    {
                        Console.WriteLine("輸入錯誤！請重新輸入！\n");
                        continue;
                    }

                    Console.Write("輸入數量： ");
                    goods_nums = int.Parse(Console.ReadLine());
                    if (goods_nums > 5 || goods_nums < 1)
                    {
                        Console.WriteLine("輸入錯誤！請重新輸入！\n");
                        continue;
                    }
                    Console.WriteLine(" ");
                    tmp = car[goods_option - 1];
                    tmp.nums += goods_nums;
                    car[goods_option - 1] = tmp;
                }
                else if (option == 3)
                {
                    Console.WriteLine("購物車內容");
                    Console.WriteLine("商品 單價 數量 小計");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(i + 1 + "." + car[i].name + " (" + money_label[cur_money] +")" + + car[i].price * money[cur_money] + " " + car[i].nums + " " + car[i].price * car[i].nums * money[cur_money]);
                    }
                    Console.Write("輸入數字選擇商品： ");
                    goods_option = int.Parse(Console.ReadLine());

                    if (goods_option == 4)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            tmp = car[i];
                            tmp.nums = 0;
                            car[i] = tmp;
                        }
                        Console.WriteLine("成功刪除商品！\n");
                        continue;
                    }
                    else if (goods_option > 3 || goods_option < 1)
                    {
                        Console.WriteLine("輸入錯誤！請重新輸入！\n");
                        continue;
                    }
                    Console.Write("輸入數量： ");
                    goods_nums = int.Parse(Console.ReadLine());

                    if (goods_nums > car[goods_option - 1].nums)
                    {
                        Console.WriteLine("輸入錯誤！請重新輸入！\n");
                        continue;
                    }
                    tmp = car[goods_option - 1];
                    tmp.nums -= goods_nums;
                    car[goods_option - 1] = tmp;
                    Console.WriteLine("成功刪除商品！\n");
                }
                else if (option == 4)
                {
                    Console.WriteLine("購物車內容");
                    Console.WriteLine("商品 單價 數量 小計");
                    for (int i = 0; i < 3; i++)
                    {
                        if (car[i].nums == 0) continue;
                        Console.WriteLine(i + 1 + "." + car[i].name + " (" + money_label[cur_money]+ ")" + car[i].price * money[cur_money] + " " + car[i].nums + " " + car[i].price * money[cur_money] * car[i].nums);
                    }
                    Console.WriteLine(" ");
                }
                else if (option == 5)
                {
                    Console.WriteLine("訂單商品");
                    Console.WriteLine("商品 單價 數量 小計");
                    double sum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        sum += car[i].nums * car[i].price * money[cur_money];
                        if (car[i].nums == 0) continue;
                        Console.WriteLine(i + 1 + "." + car[i].name + " (" + money_label[cur_money] + ")" + car[i].price * money[cur_money] + " " + car[i].nums + " " + car[i].price * money[cur_money] * car[i].nums);
                    }
                    Console.WriteLine("總價 = " + sum);
                    Console.Write("*是否要結帳(Y/N)*:");
                    string s;
                    s = Console.ReadLine();
                    if (s == "Y")
                    {
                        bool flag = true;
                        for(int i = 0; i < 3; i++)
                        {
                            if (car[i].nums > stock[i])
                            {
                                Console.WriteLine(car[i].name + "庫存不足!剩餘數量" + stock[i] +"!");
                                flag = false;
                            }
                        }
                        int op;
                        bool flag2 = false;
                        if (flag)
                        {
                            Console.Write("*選擇結帳方式(1. 線上支付 2. 貨到付款):");
                            op = int.Parse(Console.ReadLine());
                            if(!(op == 1 || op == 2))
                            {
                                Console.WriteLine("輸入錯誤！請重新輸入！\n");
                                continue;
                            }
                            else
                            {
                                Console.Write("*折扣碼(若無折扣碼則輸入N):");
                                s = Console.ReadLine();
                                if(s == "1111")
                                {
                                    flag2 = true;
                                }
                                else if(s == "N")
                                {
                                    flag2 = false;
                                }
                                else
                                {
                                    Console.WriteLine("輸入錯誤！請重新輸入！\n");
                                    continue;
                                }
                                if (flag2)
                                {
                                    Console.WriteLine("訂單狀態");
                                    Console.WriteLine("商品 單價 數量 小計");
                                    sum = 0;
                                    for (int i = 0; i < 3; i++)
                                    {
                                        sum += car[i].nums * car[i].price * money[cur_money];
                                        if (car[i].nums == 0) continue;
                                        Console.WriteLine(i + 1 + "." + car[i].name + " (" + money_label[cur_money] + ")" + car[i].price * money[cur_money] + " " + car[i].nums + " " + car[i].price * money[cur_money] * car[i].nums);
                                    }
                                    Console.WriteLine("總價 = " + sum);
                                    Console.WriteLine("總計 = " + sum * 0.95);
                                    if(op == 1)
                                    {
                                        Console.WriteLine("狀態:已付款");
                                    }
                                    else
                                    {
                                        Console.WriteLine("狀態:尚未付款");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("訂單狀態");
                                    Console.WriteLine("商品 單價 數量 小計");
                                    sum = 0;
                                    for (int i = 0; i < 3; i++)
                                    {
                                        sum += car[i].nums * car[i].price * money[cur_money];
                                        if (car[i].nums == 0) continue;
                                        Console.WriteLine(i + 1 + "." + car[i].name + " (" + money_label[cur_money] + ")" + car[i].price * money[cur_money] + " " + car[i].nums + " " + car[i].price * money[cur_money] * car[i].nums);
                                    }
                                    Console.WriteLine("總價 = " + sum);
                                    if (op == 1)
                                    {
                                        Console.WriteLine("狀態:已付款");
                                    }
                                    else
                                    {
                                        Console.WriteLine("狀態:尚未付款");
                                    }
                                }
                                for (int i = 0; i < 3; i++)
                                {
                                    tmp.nums = 0; tmp.price = car[i].price; tmp.name = car[i].name;
                                    stock[i] -= car[i].nums;
                                    car[i] = tmp;
                                }
                            }
                        }
                        Console.WriteLine(" ");
                    }
                    else if(s == "N")
                    {
                        Console.WriteLine(" ");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("輸入錯誤！請重新輸入！\n");
                        continue;
                    }
                }
                else if(option == 6)
                {
                    Console.Write("選擇貨幣 1.TWD 2.USD 3.CNY 4.JPY :");
                    cur_money = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                }
                else if (option == 7)
                {
                    break;
                }
            }
        }
    }
}