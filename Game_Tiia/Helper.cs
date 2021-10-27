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
        public static void CheckLevel(Player player) //spelaren uppnår en ny level när exp=100
        {
            if (player.Exp >= 100)
            {
                player.Level++;
                Console.WriteLine($"Congratulation you leveled up! You are now on level {player.Level}");
                Thread.Sleep(500);
                Console.Clear();
            }
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

        internal static void CheckIfAlive(SpecificMonster monster, Player player) //kontrollerar om antingen spelare eller monster är död
        {
            ShowHp(player, monster);
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                Console.WriteLine($"\nVICTORY!! You killed the monster and gained {monster.ExpGiven} exp.");
                player.Exp = +monster.ExpGiven;
                Console.WriteLine($"\nYou are on level {player.Level}, have {player.Exp} exp and {player.Hp} hp");
                return;
            }
            else if (player.Hp <= 0)
            {
                player.Hp = 0;
                Console.WriteLine("\nYou fought bravely but that wasn't enough... you were KILLED by the monster!");
            } 
        }

        public static void ShowHp(Player player, SpecificMonster monster) //visar HP på både spelare och monstret
        {
            Console.WriteLine($"{player.Name}: [{player.Hp}] hp");
            Console.WriteLine($"{monster.Name}: [{monster.Hp}] hp");
        }
    }
}
