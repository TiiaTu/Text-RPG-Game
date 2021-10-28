using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Visual
    {
        public static void WanderingAround() //ser lite ut som små fotsteg (?)
        {
            Visual.ChangeToCyan();

            for (int i = 0; i < 6; i++)
            {
                Console.Write(" °");
                Thread.Sleep(250);
                Console.Write(" o");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("══════════════════════════════");
            Console.Clear();
        }

        

        public static void ChangeToCyan() //ändrar färgen på texten till cyan
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void ChangeToMagenta() //ändrar färgen på texten till magenta
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        public static void YellowLine()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--------------------------");
            Console.ResetColor();
        }
        public static void SeparateLine()
        {
            Console.WriteLine("---------------------------\n");
        }
    }
}
