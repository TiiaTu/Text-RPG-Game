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

            while (monster.Hp >= 0)
            {
                Random rnd = new Random();
                var fightScenario = rnd.Next(1, 4);

                switch (fightScenario)
                {
                    case 1: BasicFight(player, monster, damageGiven, damageGiven2, damageTaken, damageTaken2); break;
                    case 2: LongerFight(player, monster, damageGiven, damageGiven2, damageTaken, damageTaken2); break;
                    case 3: MonsterWantsGold(player, monster); break;
                    default: Console.WriteLine("Invalid input"); break;
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
        //---------------första scenario------------------------------------------------------
        private static void BasicFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            Visual.ChangeToMagenta();
            Check.PressEnter();
            Console.WriteLine($"\tAAAH! The monster rages towards you and hits you! You lose {damageTaken} hp");
            player.Hp -= (damageTaken - player.Toughness);
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\n\tYou swing your sword and slash the monster! The monster loses {damageGiven} hp");
            monster.Hp -= (damageGiven+player.Strenght);
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

        //-----------------andra scenario----------------------------------------------------------
        private static void LongerFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            Visual.ChangeToMagenta();
            Console.WriteLine($"\tYou draw your sword and run towards {monster.Name}.. but you miss!");
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\tThis seems to give the monster even more energy and before you realise it,");
            Console.WriteLine("\tyou get punched right in to the chest!");
            Check.PressEnter();

            Console.WriteLine($"\tThis catches you complitely off guard and thrusts you to the ground,");
            Console.WriteLine($"\tYou lose {damageTaken * 2} hp");
            player.Hp -= ((damageTaken * 2)-player.Toughness);
            Check.PressEnter();

            Console.WriteLine($"\tBefore you have time to get up {monster.Name} lifts you up to the air");
            Console.WriteLine("\tand tosses you like a ragdoll..");
            Console.WriteLine("\tthings are not looking good for you");

            Console.WriteLine("\t\nYou suddenly get a slight chance to escape if you start to run now!!");
            Console.WriteLine("\tDo you want to use the opportunity? y/n");
            
            Visual.Countdown();

            var userInput = Console.ReadLine();
            if (userInput == "y")
            {
                return;
            }
            else
            {
                Visual.ChangeToMagenta();
                Console.WriteLine($"\tThere's no escaping now! Even though your whole body is on fire,");
                Console.WriteLine($"\tyou take few surprisingly quick steps and swing your sword towards {monster.Name} and succeed in hitting it!");
                Console.WriteLine($"\t{monster.Name} loses {damageGiven} hp!");
                monster.Hp -= damageGiven;
                Check.PressEnter();

                Console.WriteLine($"\tNow you got some new energy hit the monster to the leg! It howls of pain and loses {damageGiven2} hp!");
                monster.Hp -= damageGiven2;

                Console.WriteLine("Before the monster gets up, you get your chance to finish the monster with one powerful hit!");
                monster.Hp = 0;
            }
            Check.EnterToContinue();
        }

        //--------------------tredje scenario------------------------------------------------------------------ 

        private static void MonsterWantsGold(Player player, Monster monster)
        {
            return;
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

