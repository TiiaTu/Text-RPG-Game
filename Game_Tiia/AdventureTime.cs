using System;
using System.Threading;

namespace Game_Tiia
{
    class AdventureTime
    {
        public static void WhileOnAdventure(Player player)
        {
            WelcomeToForest();

            while (player.Level < 10)
            {
                WanderingAround();
                int monsterOrNot = Randomizer();

                if (monsterOrNot == 1)
                {
                    Message("It's so quiet and peaceful... a little bit too quiet maybe, but no monsters on sight lyckily.. Enjoy while you can!");
                }
                else if (monsterOrNot == 5)
                {
                    Message("Oh look! You meet another travelers that turns out to be extremely friendly! \nYou chat with them and regain some of your powers! \nIn exchange for some food, they give you a peace of GOLD!");
                    player.Gold++;
                    player.Hp += 5;
                }
                else
                {
                    MonsterEncounter(player);
                }

                //if(player.)

                string input = DoYouWantToContinue();

                if (input == "Y") continue;
                else if (input == "N") break;
                else
                {
                    Message("Enter 'Y' or 'N' ");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private static void Message(string message)
        {
            Console.WriteLine(message);
        }

        private static void PressEnter()
        {
            Message("\n[Press enter to continue]");
            Console.ReadKey();
        }

        private static void MonsterEncounter(Player player)
        {
            int level = player.Level;

            if (level < 3)
            {
                SpecificMonster monster1 = new SpecificMonster();
                monster1.Name = "an old and crumpy Goblin with stinky feet";
                monster1.Hp = 50;
                Attack(player, monster1);
            }

            else if (level > 3 && level <= 6)
            {
                SpecificMonster monster2 = new SpecificMonster();
                monster2.Name = "an extremely unpleasant Troll";
                monster2.Hp = 75;
                Message("While strolling in the woods");
                Attack(player, monster2);
            }

            else if (level > 6 && level <= 8)
            {
                SpecificMonster monster3 = new SpecificMonster();
                monster3.Name = "a loud and hairy Orc with an axe";
                monster3.Hp = 100;
                Attack(player, monster3);
            }

            else
            {
                SpecificMonster bossMonster = new SpecificMonster();
                bossMonster.Name = "a giant Giant with giant beard";
                bossMonster.Hp = 150;
                Attack(player, bossMonster);
            }
        }

        private static void WelcomeToForest() //Början av äventyret
        {
            Message("You stand on the edge of the old, dark and spine-chilling forest. \nDreadful monsters are lurking in every corner waiting for the right moment to gobble up innocent travelers... \nDo you have the courage to enter?");
            Console.ReadLine();
            Message("The adventure begins...");
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
            for (int i = 0; i < 6; i++)
            {
                Console.Write(" °");
                Thread.Sleep(250);
                Console.Write(" o");
                Thread.Sleep(250);
            }

            Message("");
        }

        private static void SuperMonsterEncounter() //En metod för när man träffar ett kraftigare monster
        {


        }

        private static void Attack(Player player, SpecificMonster monster) //Själva slagsmålet
        {
            HelperClass.ShowHp(player, monster);
            
            Random rnd = new Random();
            var damageGiven = rnd.Next(player.Strenght, player.Strenght * 2);
            var damageTaken = rnd.Next(player.Strenght, player.Strenght * 2);

            Message($"You swing your sword and slash the monster! The monster loses {damageGiven} hp");
            monster.Hp -= damageGiven;
            Message($"Oh no you made it angry, the monster rages towards you and hits you! You lose {damageTaken} hp");
            player.Hp -= damageGiven-player.Toughness;
            
            HelperClass.ShowHp(player, monster);

        }

        

        private static void AttackSuperMonster()
        {
            throw new NotImplementedException();
        }

        private static string DoYouWantToContinue()
        {
            Console.Write("Do you want to continue the adventure? (Y/N) ");
            var input = Console.ReadLine().ToUpper();
            return input;
        }
    }
}
