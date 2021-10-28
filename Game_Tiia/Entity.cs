using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    public interface IEntity
    {
        public string Name { get; set; }
        public int Hp { get; set; }
    }

    public class Player : IEntity
    {
        public string Name { get; set; } = "";
        public int Hp { get; set; } = 200;
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int Strenght { get; set; } = 5;
        public int Toughness { get; set; } = 0;
        public int Gold { get; set; } = 20;

        public static void GetGold(Player player, int amountGold)
        {
            player.Gold+=amountGold;
            Console.WriteLine($"You got {amountGold} gold, and have now {player.Gold} gold");
        }

        public static void GiveGold(Player player, int amountGold)
        {
            Console.WriteLine($"You have: {player.Gold} gold. How much gold do you want to give? ");            
            int.TryParse(Console.ReadLine(), out amountGold);
            Console.WriteLine(amountGold);
            player.Gold -= amountGold;
            
        }
    }

    class Monster : IEntity
    {
        public string Name { get; set; } = "";
        public int Hp { get; set; } = 0;
        public int ExpGiven { get; set; } = 0;
       
        public static void DropGold(Player player, Monster monster) //monstret tappar guld ibland
        {
            Random rnd = new Random();
            var dropGold = rnd.Next(1, 11);

            if (dropGold == 9 || dropGold == 10)
            {
                Console.WriteLine("You loot the monster and find a peace of GOLD!");
                Player.GetGold(player);
            }
            else
            {
                Console.WriteLine("This monster didn't have any gold");
            }
        }
    }
}


