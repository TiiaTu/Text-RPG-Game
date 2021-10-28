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
            
            Helper.ShowHp(player, monster);

            do
            {
                Console.WriteLine($"\n\t>>You swing your sword and slash the monster! The monster loses {damageGiven} hp");
                monster.Hp -= damageGiven;
                Console.WriteLine($"\t>>AAAH! The monster rages towards you and hits you! You lose {damageTaken} hp");
                player.Hp -= (damageTaken - player.Toughness);
                Console.WriteLine($"\t>>You survive the hit, make a skillfull maneuver and succeed in hitting the monster again. \n\tThe monster loses {damageGiven2} hp ");
                monster.Hp -= damageGiven2;
                Console.WriteLine($"\t>>But the monster is too fast and you get hit again, this time you lose {damageTaken2} hp");
                player.Hp -= (damageTaken2 - player.Toughness);
                Console.WriteLine();

                Helper.ShowHp(player, monster);
                
                if (monster.Hp <= 0)
                {
                    monster.Hp = 0;
                    Visual.ChangeToMagenta();
                    Console.Write($"\nVICTORY!!");
                    Console.ResetColor();
                    Console.WriteLine($"You killed the monster and gained {monster.ExpGiven} exp.");
                    player.Exp += monster.ExpGiven;
                    Monster.DropGold(player, monster);

                    Visual.YellowLine();
                    Console.WriteLine($"Level     : {player.Level}");
                    Console.WriteLine($"Exp       : {player.Exp} exp");
                    Console.WriteLine($"Hp        : {player.Hp} hp");
                    Console.Write($"Gold      : {player.Gold}");
                    Visual.YellowLine();
                    break;
                }
                else if (player.Hp <= 0)
                {
                    player.Hp = 0;
                    Visual.ChangeToCyan();
                    Console.Write("GAME OVER :( ");
                    Console.ResetColor();
                    Console.WriteLine("\nYou fought bravely but that wasn't enough... you were KILLED by the monster!");
                    break;
                }
                //Helper.CheckIfAlive(monster, player);
                //Helper.ShowHp(player, monster);

                //Monster.DropGold(player, monster);
                //Player.GetGold(player);

                Helper.PressEnter();
                Console.Clear();
            }
            while (monster.Hp >= 0);
            
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

