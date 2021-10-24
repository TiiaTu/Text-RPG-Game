using System;

namespace Game_Tiia
{
    class Adventure
    {
        public static void WhileOnAdventure()
        {

            Random rand = new Random();
            var monsterOrNot = rand.Next(1, 11);
            Console.WriteLine(monsterOrNot);

            if (monsterOrNot== 1)
            {
                Console.WriteLine("It's so quiet and peaceful.. No monsters on sight.. Enjoy while you can..");
                Console.WriteLine("\n[Press enter to continue]");
                Console.ReadKey();
                return;
            }
            else
            {

            }
        }
    }
}
