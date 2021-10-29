using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Check //en klass för att kontrollera och visa input och annat från användaren
    {
        public static void CheckLevel(Player player) //spelaren uppnår en ny level när exp=100 och får 200 hp
        {
            if (player.Exp >= 100)
            {
                player.Level++;
                player.Exp = 0;
                player.Hp = 200;
                Console.Write("\nCONGRATULATIONS! You leveled up! ");
                Console.Write("You are now on level ");
                Visual.ChangeToCyan();
                Console.WriteLine($"{player.Level}");
                Console.ResetColor();
                PressEnter();
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

        public static void PressEnter()
        {
            Console.ReadKey();
            Console.WriteLine();
        }

        public static void EnterToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n[Press enter to continue]");
            Console.ResetColor();
            Console.ReadKey();
        }

            public static string DoYouWantToContinue()
        {
            Console.Write("\nDo you want to continue the adventure? y/n ");
            var input = Console.ReadLine().ToLower();
            return input;
        }

        public static void ShowHp(Player player, Monster monster) //visar HP på både spelare och monstret
        {
            Console.WriteLine($"\n\t{player.Name}: {player.Hp} hp |VS| {monster.Name}: {monster.Hp} hp ");
            Console.WriteLine("\t═══════════════════════════════════════════════════════");
        }

        public static void ShowStats(Player player)
        {
            Visual.BlueLine();
            Console.WriteLine($"Level     : {player.Level}");
            Console.WriteLine($"Exp       : {player.Exp} exp");
            Console.WriteLine($"Hp        : {player.Hp} hp");
            Console.Write($"Gold      : {player.Gold}");
            Visual.BlueLine();
        }
    }
}
