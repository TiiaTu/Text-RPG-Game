using System;

namespace Game_Tiia
{
    public class Player : IEntity
    {
        public string Name { get; set; } = "";
        public int Hp { get; set; } = 200;
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int Strenght { get; set; } = 0;
        public int Toughness { get; set; } = 0;
        public int Gold { get; set; } = 20;

        public static void GetGold(Player player, int amountGold)
        {
            player.Gold+=amountGold;
            Console.WriteLine($"You got {amountGold} gold");
        }

        public static void GiveGold(Player player, int amountGold)
        {
            Console.WriteLine($"You have: {player.Gold} gold. How much gold do you want to give? ");            
            int.TryParse(Console.ReadLine(), out amountGold);
            Console.WriteLine(amountGold);
            player.Gold -= amountGold;         
        }
    }
}


