using System;
using System.Threading;

namespace Game_Tiia
{
    class AdventureTime
    {
        public static void WhileOnAdventure(Player player)
        {
            WelcomeToForest();

            while (true)
            {
                WanderingAround();
                int monsterOrNot = Randomizer();

                switch (monsterOrNot)
                {
                    case 1:
                        Message("It's so quiet and peaceful... a little bit too quiet maybe, but no monsters on sight lyckily.. Enjoy while you can!");
                        break;
                    case 5:
                        Message("\nOh look! You meet another travelers that turns out to be extremely friendly! \nYou chat with them and regain some of your powers! \nIn exchange for some food, they give you a peace of GOLD!");
                        player.Gold++;
                        player.Hp += 10;
                        break;
                    case 7:
                        Message("You start to feel exhausted and decide stop and rest for a while. Something caughts your attention.. sounds like running water! \nYou proceed to check where it's coming from and find a small stream of water. You take a sip from the stream and gain 25 hp! ");
                        player.Hp += 25;
                        break;
                    default:
                        MonsterEncounter(player);
                        Helper.CheckLevel(player);
                        break;
                }

                string input = Helper.DoYouWantToContinue(); //ger en möjlighet att avbryta äventyret

                if (input == "Y") continue;
                else if (input == "N") break;
                else Message("Enter 'Y' or 'N' "); Console.ReadLine(); Console.Clear();
            }
                Console.Clear();          
        }

        private static void MonsterEncounter(Player player) //spelaren träffar olika monster beroende på nivån denna befinner sig i
        {
            int level = player.Level;

            if (level < 3)
            {
                SpecificMonster monster1 = new();
                monster1.Name = "an old and crumpy Goblin with stinky feet";
                monster1.Hp = 50;
                monster1.ExpGiven = 25;
                Message($"You stumble across {monster1.Name}! He looks kind of hungry...  Good luck! ");
                Attack.AttackMonster(player, monster1);
            }
            else if (level > 3 && level <= 6)
            {
                SpecificMonster monster2 = new();
                monster2.Name = "an extremely unpleasant Troll";
                monster2.Hp = 75;
                monster2.ExpGiven = 50;
                Message($"While strolling in the woods you suddenly hear heavy steps behind you. You turn around and see {monster2.Name} and it's too late to hide! ");
                Attack.AttackMonster(player, monster2);
            }
            else if (level > 6 && level <= 8)
            {
                SpecificMonster monster3 = new();
                monster3.Name = "a loud and hairy Orc with an axe";
                monster3.Hp = 100;
                monster3.ExpGiven = 50;
                Attack.AttackMonster(player, monster3);
            }
            else
            {
                SpecificMonster bossMonster = new();
                bossMonster.Name = "a giant Giant with giant beard";
                bossMonster.Hp = 150;
                bossMonster.ExpGiven = 75;
                Attack.AttackMonster(player, bossMonster);
            }
        }

        private static void WelcomeToForest() //Början av äventyret
        {
            Message("You stand on the edge of the old, dark and spine-chilling forest. \nDreadful monsters are lurking in every corner waiting for the right moment to gobble up innocent travelers... \nDo you have the courage to enter?");
            Console.ReadLine();
            Console.Write("And so begins the adventure...");
        }

        private static int Randomizer() //genererar ett nummer mellan 1 och 10 som används för att utgöra vilket monster man träffar
        {
            Random rand = new Random();
            var monsterOrNot = rand.Next(1, 11);
            Console.WriteLine(monsterOrNot); //TA BORT I SLUTET
            return monsterOrNot;
        }

        private static void WanderingAround() //ser lite ut som små fotsteg (?)
        {
            Visual.ChangeToCyan();

            for (int i = 0; i < 6; i++)
            {
                Console.Write(" °");
                Thread.Sleep(250);
                Console.Write(" o");
                Thread.Sleep(250);
            }
            Message("");
            Console.ResetColor();
            Console.WriteLine("══════════════════════════════");
        }

        private static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
