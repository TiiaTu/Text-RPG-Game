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
            Random rnd = new Random();
            var damageGiven = rnd.Next(player.Strenght, player.Strenght * 2);
            var damageGiven2 = rnd.Next(player.Strenght, player.Strenght * 2);
            var damageTaken = rnd.Next(player.Strenght, player.Strenght * 2);
            var damageTaken2 = rnd.Next(player.Strenght, player.Strenght * 2);

            while (true)
            {
                Message($"\n\t>>You swing your sword and slash the monster! The monster loses {damageGiven} hp");
                monster.Hp -= damageGiven;
                Message($"\t>>AAAH! The monster rages towards you and hits you! You lose {damageTaken} hp");
                player.Hp -= (damageTaken - player.Toughness);
                Message($"\t>>You survive the hit, make a skillfull maneuver and succeed in hitting the monster again. \n\tThe monster loses {damageGiven2} hp ");
                monster.Hp -= damageGiven2;
                Message($"\t>>But the monster is too fast and you get hit again, this time you lose {damageTaken2} hp");
                player.Hp -= (damageTaken2 - player.Toughness);
                Message("");

                int gainedExperience = player.Exp;

                if (monster.Hp <= 0)
                {
                    Console.WriteLine($"\nVictory!! You killed the monster and gained {monster.ExpGiven} exp.");
                    gainedExperience = +monster.ExpGiven;
                    Message($"\nYou are on level {player.Level}, have {player.Exp} exp and {player.Hp} hp");
                    break;
                }
                else if (player.Hp <= 0)
                {
                    Console.WriteLine("\nYou fought bravely but that wasn't enough... you were KILLED by the monster!");
                    break;
                }

                Helper.ShowHp(player, monster); //visar HP på både spelare och monstret

                Helper.PressEnter();
                Console.Clear();
            }
        }
    }
}
