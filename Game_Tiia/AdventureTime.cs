using System;
using System.Threading;

namespace Game_Tiia
{
    class AdventureTime
    {
        public static void WhileOnAdventure()
        {
            WelcomeToForest();
            while (true)
            {
                WanderingAround();
                int monsterOrNot = Randomizer();

                switch (monsterOrNot)
                {
                    case 1:
                        Console.WriteLine("It's so quiet and peaceful... a little bit too quiet maybe, but no monsters on sight lyckily.. Enjoy while you can!");
                        Console.WriteLine("\n[Press enter to continue]");
                        Console.ReadKey();
                        break;
                    case 2:
                        SpecificMonster iku = new SpecificMonster();
                        iku.Name = "A dreadful IKU-TURSO";
                        Console.WriteLine($"You arrive at a deep dark lake. There is a little old boat on the shore, so you decide to take it. In the middle of the lake the water around you starts suddenly bubbling violently!! You see a climpse of {iku.Name} that is trying to capsize the boat!!");
                        Attack();
                        break;
                    case 3:
                        SpecificMonster hiisi = new SpecificMonster();
                        hiisi.Name = "A mysterious HIISI";
                        Console.WriteLine($"Oh no! There is {hiisi.Name} standing right in front of you! You have tresspassed it's territory!");
                        Attack();
                        break;
                    case 5:
                        SpecificMonster näkki = new SpecificMonster();
                        näkki.Name = "A scary NÄKKI";
                        Console.WriteLine($"You arrive in a dark river in the forest. The only way is to swim across {näkki.Name}!");
                        Attack();
                        break;
                    case 10:
                        SpecificMonster louhi = new SpecificMonster();
                        louhi.Name = "An nearly unbeatable LOUHI";
                        Console.WriteLine($"Why is the ground shaking all of a sudden? Is it.. Could it be.. Yes it's {louhi.Name}!! Good luck fighting this one.. ");
                        SuperMonsterEncounter(); break;

                    default:
                        SpecificMonster peikko = new SpecificMonster();
                        peikko.Name = "A fearsome PEIKKO";
                        Console.WriteLine($"Oh no! You have encountered {peikko.Name}!");
                        Attack();
                        break;
                }
                Console.Write("Do you want to continue the adventure? (Y/N) ");
                var input = Console.ReadLine().ToUpper();

                if (input == "Y") continue;
                else if (input == "N") break;
                else
                {
                    Console.WriteLine("Enter 'Y' or 'N' ");
                    Console.ReadLine();
                }
            }
        }

        private static int Randomizer()
        {
            Random rand = new Random();
            var monsterOrNot = rand.Next(1, 11);
            Console.WriteLine(monsterOrNot);
            return monsterOrNot;
        }

        private static void WanderingAround()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" °");
                Thread.Sleep(250);
                Console.Write(" o");
                Thread.Sleep(250);
            }
        }

        private static void WelcomeToForest()
        {
            Console.WriteLine("You stand on the edge of the finnish forest of folklore called 'Sysimetsä'. Dreadful monsters are lurking in every corner... Do you have the courage to enter?");
            Console.ReadLine();
        }

        private static void SuperMonsterEncounter()
        {
            
        }

        private static void Attack()
        {
            Console.WriteLine("You take your sword and slash the monster! ");
        }

        private static void AttackSuperMonster()
        {
            throw new NotImplementedException();
        }
    }
}
