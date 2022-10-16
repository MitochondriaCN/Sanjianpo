using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjianpo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                CH.WT("三监破　v0.1");
                CH.WL("功能：");
                CH.WL("\t(1)新建破解计划向导");
                CH.WL("\t(2)查看破解计划");
                CH.WL("\t(3)启动破解计划");
                CH.WL("\t(4)关于");
                CH.WL();
                CH.W("请选择（1-4）：");
                switch (Console.ReadLine())
                {
                    case "1":
                        Functions.CreateNewPlan();
                        break;
                    case "2":
                        Functions.CheckPlan();
                        break;
                    case "3":
                        Functions.StartPlan();
                        break;
                    case "4":
                        Functions.About();
                        break;
                }
            }
        }
    }
}
