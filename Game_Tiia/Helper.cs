using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Helper
    {
        public static void CheckLevel(Player player)
        {
            if(player.Exp>=100)
            {
                player.Level++;
                Console.WriteLine($"Congratulation you leveled up! You are now on level {player.Level}");
                Thread.Sleep(500);
                Console.Clear();
            }
        }
        public static void ShowHp(Player player, SpecificMonster monster)
        {
            Console.WriteLine($"{player.Name}: [{player.Hp}] hp");
            Console.WriteLine($"{monster.Name}: [{monster.Hp}] hp");
        }

        public static void PressEnter()
        {
            Console.WriteLine("\n[Press enter to continue]");
            Console.ReadKey();
        }

        public static string DoYouWantToContinue()
        {
            Console.Write("Do you want to continue the adventure? (Y/N) ");
            var input = Console.ReadLine().ToUpper();
            return input;
        }
    }
}
