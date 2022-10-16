using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace Sanjianpo
{
    internal class Functions
    {
        public static void CreateNewPlan()
        {
            CH.CL();
            CH.WT("新建破解计划向导");

            bool flag = false;
            int beginNum = 0, endNum = 0;
            while (!flag)
            {
                try
                {
                    CH.W("1.设置尝试起始值（6位）：");
                    beginNum = int.Parse(Console.ReadLine());
                    CH.W("2.设置尝试结束值（6位）：");
                    endNum = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException e)
                {
                    CH.WE("输入的数值不合法，请重试。");
                }
            }

            flag = false;
            int tick = 0;
            while (!flag)
            {
                CH.W("设置两次尝试间的间隔（单位：ms）：");
                try
                {
                    tick = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException e)
                {
                    CH.WE("输入的数值不合法，请重试。");
                }
            }

            CH.CL();
            CH.WT("新建破解计划向导 - 确认计划");
            CH.WL("\t起始尝试值：" + beginNum);
            CH.WL("\t结束尝试值：" + endNum);
            CH.WL("\t尝试间隔：" + tick + " ms");
            CH.WL();
            CH.W("确认（Y/N）：");
            switch (Console.ReadLine())
            {
                default:
                case "N":
                case "n":
                    CH.WE("计划未保存，按任意键回到主页。");
                    Console.ReadKey();
                    return;
                case "Y":
                case "y":
                    try
                    {
                        File.WriteAllText("plan.sjp", beginNum + "\n" + endNum + "\n" + tick);
                        CH.WS("计划保存成功，按任意键回到主页。");
                        Console.ReadKey();
                        return;
                    }
                    catch (Exception e)
                    {
                        CH.WE("保存计划时发生错误：");
                        CH.WE(e.Message);
                        CH.WE("按任意键回到主界面。");
                        Console.ReadKey();
                        return;
                    }
            }
        }

        public static void CheckPlan()
        {
            CH.CL();
            CH.WT("查看破解计划");
            if (File.Exists("plan.sjp"))
            {
                string[] raw = File.ReadAllLines("plan.sjp");
                CH.WL("\t起始尝试值：" + raw[0]);
                CH.WL("\t结束尝试值：" + raw[1]);
                CH.WL("\t尝试间隔：" + raw[2] + " ms");
                CH.WL();
                CH.WS("按任意键回到主界面。");
                Console.ReadKey();
                return;
            }
            else
            {
                CH.WE("尚未创建破解计划，按任意键回到主页。");
                Console.ReadKey();
                return;
            }
        }

        public static void StartPlan()
        {
            CH.CL();
            CH.WT("启动破解计划");
            if (File.Exists("plan.sjp"))
            {
                CH.WL("请再次检查破解计划：");
                string[] raw = File.ReadAllLines("plan.sjp");
                CH.WL("\t起始尝试值：" + raw[0]);
                CH.WL("\t结束尝试值：" + raw[1]);
                CH.WL("\t尝试间隔：" + raw[2] + " ms");
                CH.WL();
                CH.W("确认（Y/N）：");
                switch (Console.ReadLine())
                {
                    default:
                    case "N":
                    case "n":
                        return;
                    case "Y":
                    case "y":
                        break;
                }

                CH.WL();
                CH.WL("现在你有15秒的时间将焦点移到密码框首位。");
                for (int i = 15; i > 0; i--)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    CH.W(i.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    CH.W(" ");
                    Thread.Sleep(1000);
                }

                //
                //破解核心程序
                //
                int begin = int.Parse(raw[0]);
                int end = int.Parse(raw[1]);
                int tick = int.Parse(raw[2]);
                int current = begin;
                DateTime beginTime = DateTime.Now;
                while (current <= end)
                {
                    CH.CL();
                    CH.WT("三监破　v0.1 - 正在破解");
                    CH.WL("开始时间：\t" + beginTime.ToString());
                    CH.WL("当前时间：\t" + DateTime.Now.ToString());
                    CH.WL("预计剩余时间：\t" + int.Parse(((150 + tick) * (end - current) / 1000 / 60).ToString()).ToString() + " min");
                    CH.WL("起始尝试：\t" + begin);
                    CH.WL("当前尝试：\t" + current);
                    CH.WL("结束尝试：\t" + end);

                    //先补全0
                    for (int i = 0; i < 6 - current.ToString().Length; i++)
                    {
                        OutputHelper.keybd_event(System.Windows.Forms.Keys.D0, 0, 0, 0);
                        Thread.Sleep(25);
                    }
                    //逐个输入数字
                    foreach (char c in current.ToString())
                    {
                        OutputHelper.keybd_event((Keys)Enum.Parse(typeof(Keys), "D" + c), 0, 0, 0);
                        Thread.Sleep(25);
                    }
                    OutputHelper.keybd_event(Keys.Enter, 0, 0, 0);
                    Thread.Sleep(tick);
                    current++;
                }
            }
        }

        public static void About()
        {
            CH.CL();
            CH.WT("三监破 - 关于");
            CH.WL("三监破　v0.1");
            CH.WL("开发：线粒体XianlitiCN");
            CH.WL("编译时间：" + File.GetLastWriteTime(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToString());
            CH.WL();
            CH.WL("希沃管家，妨碍教学，早当亡矣。道高一尺，魔高一丈。");
            CH.WL();
            CH.WS("按任意键回到主页。");
            Console.ReadKey();
            return;
        }

    }
}
