using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Menu
    {
        public static void MainHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╒═══════════════════════════════╕");
            Console.WriteLine("╞          -THE GAME-           ╡ ");
            Console.WriteLine("╘═══════════════════════════════╛");
            Console.ResetColor();
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n 1. Go adventuring");
            Console.WriteLine(" 2. Show details about your character");
            Console.WriteLine(" 3. Exit Game\n");
            Console.Write(">> ");
        }
    }
}
