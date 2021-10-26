using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class HelperClass
    {
        public static void Checkhealth(Player player)
        {
            if(player.Hp<=0)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                Console.WriteLine("You were beaten by the monster");               
            }
        }
        public static void ShowHp(Player player, SpecificMonster monster)
        {
            Console.WriteLine($"{player.Name}: {player.Hp}");
            Console.WriteLine($"{monster.Name}: {monster.Hp}");
            Console.WriteLine("\nGood luck!");
        }
    }
}
