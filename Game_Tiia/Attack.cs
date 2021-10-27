using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    class Attack
    {
        public static void AttackMonster(Player player, SpecificMonster monster) //Själva slagsmålet
        {
            int damageGiven, damageGiven2, damageTaken, damageTaken2;
            NewMethod(player, out damageGiven, out damageGiven2, out damageTaken, out damageTaken2);

            while (true)
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

                Helper.CheckIfAlive(monster, player);
                //Helper.ShowHp(player, monster);

                Helper.PressEnter();
                Console.Clear();
            }
        }

        private static void NewMethod(Player player, out int damageGiven, out int damageGiven2, out int damageTaken, out int damageTaken2)
        {
            Random rnd = new Random();
            damageGiven = rnd.Next(player.Strenght, player.Strenght * 2);
            damageGiven2 = rnd.Next(player.Strenght, player.Strenght * 2);
            damageTaken = rnd.Next(player.Strenght, player.Strenght * 2);
            damageTaken2 = rnd.Next(player.Strenght, player.Strenght * 2);
        }

    }
    }

