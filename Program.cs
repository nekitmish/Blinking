using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blinking
{
    class Program
    {
        static double printFact(int x)
        {
            if (x == 0) return 1;
            else return x * printFact(x - 1);
        }

        static void TimerInit()
        {
            TimerCallback tm = new TimerCallback(ColorWheele);
            Timer timer = new Timer(tm, null, 0, 100);
        }

        public static void WriteBoxLine(int num, char beginSym, char indentSym, char endSym)
        {
            Console.Write(beginSym);
            for (int i = 0; i < num; i++)
                Console.Write(indentSym);
            Console.WriteLine(endSym);
        }

        public static void WriteBoxLine(int num, char beginSym, char indentSym, char endSym, string str)
        {
            Console.Write(beginSym);
            Console.Write(indentSym);
            Console.Write(str);
            // ║...............║
            // ║.Hello.........║
            // ║.my dear world.║
            // 15 - 5 - 1

            int spaceNum = num - str.Length - 1;
            for (int i = 0; i < spaceNum; i++)
                Console.Write(indentSym);

            Console.WriteLine(endSym);
        }

        static void DrawBox(int num, double result)
        {
            int centerX = (Console.WindowWidth / 2) - (result.ToString().Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            WriteBoxLine(num, '╔', '═', '╗');
            Console.SetCursorPosition(centerX, centerY + 1);
            WriteBoxLine(num, '║', ' ', '║');
            Console.SetCursorPosition(centerX, centerY + 2);
            WriteBoxLine(num, '║', ' ', '║', result.ToString());
            Console.SetCursorPosition(centerX, centerY + 3);
            WriteBoxLine(num, '║', ' ', '║');
            Console.SetCursorPosition(centerX, centerY + 4);
            WriteBoxLine(num, '╚', '═', '╝');
        }
        static int colorMode = 0;
        static void ColorWheele(object obj)
        {
            ref int colorModeLocal = ref colorMode;
            if (colorModeLocal < 15) colorModeLocal++;
            else colorModeLocal = 0;
            Console.BackgroundColor = (ConsoleColor)colorModeLocal;
            Console.ForegroundColor = (ConsoleColor)(colorModeLocal % 2);
        }
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int num = printFact(x).ToString().Length + 2;
            Console.CursorVisible = false;
            Console.Clear();
            TimerInit();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape) break;
                }
                DrawBox(num, printFact(x));
            }
        }
    }
}
