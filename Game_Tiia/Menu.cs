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
            Visual.ChangeToCyan();
            Console.Write("\n  [1] ");
            Console.ResetColor();
            Console.WriteLine("Go adventuring");
            
            Visual.ChangeToCyan();
            Console.Write("  [2] ");
            Console.ResetColor();
            Console.WriteLine("Show details about your character");
            Visual.ChangeToCyan();
            
            Console.Write("  [3] ");
            Console.ResetColor();
            Console.WriteLine("Go to shop");
            Visual.ChangeToCyan();
            
            Console.Write("  [4] ");
            Console.ResetColor();
            Console.WriteLine("Exit Game\n");
            Console.Write(">> ");
        }
        internal static void ShopMenu()
        {
            Console.WriteLine("");
        }

        internal static void StartScreen()
        {
            Console.SetCursorPosition(75, 5);
            Visual.ChangeToMagenta();
            Console.WriteLine();
            Console.WriteLine("     __________   __     __   ________       __________   ________   ___    ___   ________ ");
            Console.WriteLine("    |___    ___| |  |___|  | |   _____|     |  ________| |   __   | |   |  |   | |   _____| ");
            Console.WriteLine("        |  |     |   ___   | |  |___        |  |  _____  |  |__|  | |    ||    | |  |___   ");
            Console.WriteLine("        |  |     |  |   |  | |  |_____      |  |____|  | |   __   | |  | __ |  | |  |_____ ");
            Console.WriteLine("        |__|     |__|   |__| |________|     |__________| |__|  |__| |__|    |__| |________|");
            Visual.ChangeToCyan();
            Console.WriteLine("\n                                [Press any key to Start]");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
