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
            Randomizer(player, out int damageGiven, out int damageGiven2, out int damageTaken, out int damageTaken2);

            var damageToMonster = damageGiven + player.Strenght; //så att man slipper att skriva funktionen varje gång
            var damageToMonster2 = damageGiven2 + player.Strenght;
            var damageToPlayer = damageTaken - player.Toughness;
            var damageToPlayer2 = damageTaken2 - player.Toughness;

            Check.ShowHp(player, monster);

            while (monster.Hp >= 0)
            {
                Random rnd = new Random();
                var fightScenario = rnd.Next(1, 5);

                switch (fightScenario)
                {
                    case 1: FightScenario.LongerFight(player, monster, damageGiven, damageGiven2, damageTaken, damageTaken2); break; 
                    case 2: FightScenario.MonsterWantsGold(player, monster); break; 
                    default: FightScenario.BasicFight(player, monster, damageGiven, damageGiven2, damageTaken, damageTaken2); break;
                }

                //Check.PressEnter();
                Check.ShowHp(player, monster);

                if (monster.Hp <= 0)
                {
                    monster.Hp = 0;
                    MonsterKilled(monster);
                    player.Exp += monster.ExpGiven;
                    Monster.DropGold(player, monster);
                    Check.ShowStats(player);
                    //break;
                }
                else if (player.Hp <= 0)
                {
                    player.Hp = 0;
                    GameOver(player);
                    //break;
                }

                Check.EnterToContinue();
                Console.Clear();
            }
        }

        private static void Randomizer(Player player, out int damageGiven, out int damageGiven2, out int damageTaken, out int damageTaken2)
        {
            Random rnd = new Random();
            damageGiven = rnd.Next(player.Strenght, player.Strenght * 2);
            damageGiven2 = rnd.Next(player.Strenght, player.Strenght * 2);
            damageTaken = rnd.Next(player.Strenght, player.Strenght * 2);
            damageTaken2 = rnd.Next(player.Strenght, player.Strenght * 2);
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
            Console.WriteLine("Do you want to respawn? (cost: all of your gold and exp) y/n");
            var userInput = Console.ReadLine();
            if (userInput == "y")
            {
                player.Gold = 0;
                player.Exp = 0;
            }
            if (userInput == "n")
            {
                return;
            }
        }

        private static void MonsterKilled(Monster monster)
        {
            Console.Clear();
            Visual.ChangeToMagenta();
            Menu.Victory();

            Console.ResetColor();
            Console.WriteLine($"\nYou killed the monster and gained {monster.ExpGiven} exp.");
        }

    }
}

