using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Helper //en klass för att kontrollera olika användarrelaterade saker
    {
        public static void CheckLevel(Player player) //spelaren uppnår en ny level när exp=100 och fåt 200 hp
        {
            if (player.Exp >= 100)
            {
                player.Level++;
                player.Exp = 0;
                player.Hp = 200;
                Console.Write("\nCONGRATULATIONS you leveled up! ");
                Console.WriteLine("You are now on level ");
                Visual.ChangeToCyan();
                Console.WriteLine($"{player.Level}");
                Console.ResetColor();
                Helper.PressEnter();
                Console.Clear();
            }
            else if (player.Level == 10)
            {
                while (true)
                {
                    Visual.ChangeToCyan();
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Thread.Sleep(100);
                    Console.WriteLine("\n*.*.*. Congratulations!! You won The Game!.*.*.*");
                }
            }
        }

        public static void PressEnter() //flytta eventuellt till Program?
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n[Press enter to continue]");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static string DoYouWantToContinue()
        {
            Console.Write("\n-Do you want to continue the adventure?- (Y/N) ");
            var input = Console.ReadLine().ToUpper();
            return input;
        }

        public static void ShowHp(Player player, Monster monster) //visar HP på både spelare och monstret
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\t{player.Name}: {player.Hp} hp");
            Console.ResetColor();
            Console.Write("  |VS| ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" {monster.Name}: {monster.Hp} hp \n");
            Console.ResetColor();
        }
    }
}
