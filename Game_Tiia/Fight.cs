using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Fight
    {
        public static void AttackMonster(Player player, Monster monster) //Själva slagsmålet
        {
            int damageGiven, damageGiven2, damageTaken, damageTaken2;
            Randomizer(player, out damageGiven, out damageGiven2, out damageTaken, out damageTaken2);
            
            Check.ShowHp(player, monster);

            while(monster.Hp>=0)
            {
                Visual.ChangeToCyan();
                Console.WriteLine($"\n\tYou swing your sword and slash the monster! The monster loses {damageGiven} hp");
                monster.Hp -= damageGiven;
                Check.PressEnter();

                Visual.ChangeToMagenta();
                Console.WriteLine($"\tAAAH! The monster rages towards you and hits you! You lose {damageTaken} hp");
                player.Hp -= (damageTaken - player.Toughness);
                Check.PressEnter();

                Visual.ChangeToCyan();
                Console.WriteLine($"\tYou survive the hit, make a skillfull maneuver and succeed in hitting the monster again. \n\tThe monster loses {damageGiven2} hp ");
                monster.Hp -= damageGiven2;
                Check.PressEnter();

                Visual.ChangeToMagenta();
                Console.WriteLine($"\tBut the monster is too fast and you get hit again, this time you lose {damageTaken2} hp");
                player.Hp -= (damageTaken2 - player.Toughness);
                Console.ResetColor();

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

        private static void GameOver(Player player)
        {
            Console.Clear();
            Visual.ChangeToCyan();
            
            Menu.GameOver();
            Console.ResetColor();
            
            Console.WriteLine("\nYou fought bravely but that wasn't enough... you were KILLED by the monster!");
            Respawn(player);
        }

        private static void Respawn(Player player) //ger en till chans till spelaren, men inte helt gratis ;)
        {
            Console.WriteLine("Do you want to respawn? (cost: 50% of your gold and your exp will drop to 0) y/n");
            var userInput = Console.ReadLine();
            if(userInput=="y")
            {
                player.Gold -= (player.Gold * 1/2);
                player.Exp = 0;
            }
            if(userInput=="n")
            {
                return;
            }           
        }

        private static void MonsterKilled(Monster monster)
        {
            Visual.ChangeToMagenta();
            Menu.Victory();
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

