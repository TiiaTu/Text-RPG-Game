using System;

namespace Game_Tiia
{
    class SpecificMonster : Entity
    {
        public int ExpGiven { get; set; } = 0;

        public static void DropGold() //monstret tappar guld ibland
        {
            Random rnd = new Random();
            var dropGold = rnd.Next(1, 11);

            if(dropGold==9||dropGold==10)
            {
                Console.WriteLine("You loot the monster and find a peace of GOLD!");
                Player.GetGold();
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
