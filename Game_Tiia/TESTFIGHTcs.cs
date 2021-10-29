using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class TESTFIGHTcs
    {
        public static void AttackMonster(Player player, Monster monster) //Själva slagsmålet
        {
            int damageGiven, damageGiven2, damageTaken, damageTaken2;
            Randomizer(player, out damageGiven, out damageGiven2, out damageTaken, out damageTaken2);

            Check.ShowHp(player, monster);

            Random rnd = new Random();
            var fightScenario = rnd.Next(1, 4);

            while (monster.Hp >= 0)
            {
                switch (fightScenario)
                {
                    case 1: BasicFight(player, monster, damageGiven, damageGiven2, damageTaken, damageTaken2); break;
                    case 2: LongerFight(player, monster, damageGiven, damageGiven2, damageTaken, damageTaken2); break;
                    case 3: break;
                    default:
                        break;
                }

                Check.PressEnter();
                Check.ShowHp(player, monster);

                if (monster.Hp <= 0)
                {
                    monster.Hp = 0;
                    MonsterKilled(monster);
                    player.Exp += monster.ExpGiven;
                    Monster.DropGold(player, monster);
                    Check.ShowStats(player);
                    break;
                }
                else if (player.Hp <= 0)
                {
                    player.Hp = 0;
                    GameOver(player);
                    break;
                }

                Check.EnterToContinue();
                Console.Clear();

            }
        }

        private static void LongerFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            Visual.ChangeToMagenta();
            Console.WriteLine($"\tYou draw your sword and run towards {monster.Name} ..but  and you miss! ");
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\n\tThis seems to give the monster even more energy and before you realise it, you get punched right in to the chest!");
            Check.PressEnter();

            Console.WriteLine($"\n\tThis caughts you complitely of guard and you fall to the ground, and lose {damageTaken * 2} hp");
            player.Hp -= damageTaken * 2;
            Check.PressEnter();

            Console.WriteLine($"Before you have time to get up {monster.Name} lifts you up to the air and tosses you like a ragdoll.. things are not looking good for you");
            GiveUp();
            Check.EnterToContinue();
            Check.PressEnter();
            
            Console.ResetColor();
            Check.PressEnter();
        }

        private static void GiveUp() //om situationen ser alldeles för hopplöst ut
        {
            Console.WriteLine("You have a slight chance to escape if you start to run now!! Do you want to use the opportunity? y/n");
            Visual.Countdown();
            var userInput = Console.ReadLine();
            if (userInput == "y")
            {
                return;
            }
            else if(userInput == "n")
            {
                //kod här 
            }
        }



        private static void BasicFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            Visual.ChangeToMagenta();
            Console.WriteLine($"\tAAAH! The monster rages towards you and hits you! You lose {damageTaken} hp");
            player.Hp -= (damageTaken - player.Toughness);
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\n\tYou swing your sword and slash the monster! The monster loses {damageGiven} hp");
            monster.Hp -= damageGiven;
            Check.PressEnter();

            Visual.ChangeToMagenta();
            Console.WriteLine($"\tBut the monster is fast and you get hit again, this time you lose {damageTaken2} hp");
            player.Hp -= (damageTaken2 - player.Toughness);
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\tYou survive the hit, make a skillfull maneuver and succeed in hitting the monster again. \n\tThe monster loses {damageGiven2} hp ");
            monster.Hp -= damageGiven2;
            Console.ResetColor();
            Check.PressEnter();
        }

        private static void GameOver(Player player)
        {
            Console.Clear();
            Visual.ChangeToCyan();
            Console.Write("GAME OVER :'( ");
            Console.ResetColor();
            Console.WriteLine("\nYou fought bravely but that wasn't enough... you were KILLED by the monster!");
            Respawn(player);
        }

        private static void Respawn(Player player)
        {
            Console.WriteLine("Do you want to respawn? (cost: 50% of your gold and your exp will drop to 0) y/n");
            var userInput = Console.ReadLine();
            if (userInput == "y")
            {
                player.Gold -= (player.Gold * 1 / 2);
                player.Exp = 0;
            }
            if (userInput == "n")
            {
                return;
            }
        }

        private static void MonsterKilled(Monster monster)
        {
            Visual.ChangeToMagenta();
            Console.WriteLine("\n═════════");
            Console.Write($"\n ║ VICTORY!! ║");
            Console.WriteLine("\n═════════");
            Console.ResetColor();
            Console.WriteLine($"\nYou killed the monster and gained {monster.ExpGiven} exp.");
        }


        private static void Randomizer(Player player, out int damageGiven, out int damageGiven2, out int damageTaken, out int damageTaken2)
        {
            Random rnd = new Random();
            damageGiven = rnd.Next(player.Strenght, player.Strenght * 2);
            damageGiven2 = rnd.Next(player.Strenght, player.Strenght * 2);
            damageTaken = rnd.Next(player.Strenght, player.Strenght * 2);
            damageTaken2 = rnd.Next(player.Strenght, player.Strenght * 2);
        }
    }
}

