using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjianpo
{
    internal class CH
    {
        /// <summary>
        /// 输出普通文本。
        /// </summary>
        /// <param name="text"></param>
        public static void W(string text)
        {
            Console.Write(text);
        }
        /// <summary>
        /// 输出一行普通文本。
        /// </summary>
        /// <param name="text"></param>
        public static void WL(string text = "")
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// 输出标题。
        /// </summary>
        /// <param name="text"></param>
        public static void WT(string text)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            WL("              " + text + "              ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            WL();
            WL();
        }

        /// <summary>
        /// 输出错误。
        /// </summary>
        /// <param name="text"></param>
        public static void WE(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            WL(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 输出成功。
        /// </summary>
        /// <param name="text"></param>
        public static void WS(string text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            WL(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 清屏。
        /// </summary>
        public static void CL()
        {
            Console.Clear();
        }
    }
}
