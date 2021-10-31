using System;
using System.Threading;

namespace Game_Tiia
{
    internal class FightScenario
    {
        //----------------------första scenario------------------------------------------------------
        public static void BasicFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            var damageToPlayer = (damageTaken - player.Toughness);
            var moreDamageToPlayer = (damageTaken2 - player.Toughness);
            var damageToMonster = (damageGiven + player.Strenght);
            var moreDamageToMonster = (damageGiven2 + player.Strenght);

            while (monster.Hp >= 0)
            {
                Visual.ChangeToMagenta();
                Check.PressEnter();
             
                Console.Write($"\tAAAH! The monster rages towards you and hits you the shoulder! You lose {damageToPlayer} hp");
                player.Hp -= damageToPlayer;
                Check.PressEnter();

                Visual.ChangeToCyan();
                Console.WriteLine($"\n\tYou swing your sword and cut {monster.Name} in the stomach! That can't have felt good... \n\tThe monster loses {damageToMonster} hp");
                monster.Hp -= damageToMonster;
                Check.PressEnter();

                Visual.ChangeToMagenta();
                Console.WriteLine($"\tNevermind.. You might have underestimated the situation and get a sharp punch to the head! You lose {moreDamageToPlayer} hp");
                player.Hp -= moreDamageToPlayer;
                Check.PressEnter();

                Visual.ChangeToCyan();
                Console.WriteLine($"\tYou survive the hit, make a skillfull maneuver round the monster and get in a good stab to the back. \n\tThe monster lets out a nasty screeck and loses {moreDamageToMonster} hp ");
                monster.Hp -= moreDamageToMonster;
                Console.ResetColor();
                Check.PressEnter();

                Check.ShowHp(player, monster);
                Console.Clear();

                Visual.ChangeToMagenta();
                Console.WriteLine("\tWhile the monster is down on the ground, you jump over it to finish the fight");
                Thread.Sleep(2000);

                Visual.ChangeToMagenta();
                Console.WriteLine("\tBut it turns around at the exact same moment and kicks you hard so that you fly high up to the air!");
                Thread.Sleep(2000);
                Console.WriteLine($"\tThe power of the kick makes you to drop your sword..");
                Thread.Sleep(2000);
                Console.WriteLine("\t..That for your luck happens to land blade down straight into {monster.Name}s foot!");
                Check.PressEnter();
                Console.WriteLine($"\tYou lose {damageToPlayer} hp and the monster {damageToMonster} hp");

                Check.ShowHp(player, monster);

            }
            
        }

        //-------------------------andra scenario----------------------------------------------------------
        public static void LongerFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            var damageToPlayer = (damageTaken - player.Toughness);
            var damageToMonster = (damageGiven + player.Strenght);
            var moreDamageToMonster = (damageGiven2 + player.Strenght);

            while (monster.Hp >= 0)
            {
                Console.WriteLine("Here we go again..");
                Visual.ChangeToMagenta();
                Check.PressEnter();
                Console.WriteLine($"\tYou draw your sword and run towards {monster.Name}.. but you miss!");
                Check.PressEnter();

                Visual.ChangeToCyan();
                Console.WriteLine($"\tThis seems to give the monster even more energy and before you realise it,");
                Console.Write("\tyou get punched right in to the chest!");
                Check.PressEnter();

                Console.WriteLine($"\tThe punch catches you complitely off guard and thrusts you to the ground,");
                Console.WriteLine($"\tYou lose {damageToPlayer} hp");
                player.Hp -= damageToPlayer;
                Check.PressEnter();

                Console.WriteLine($"\tBefore you have time to get up {monster.Name} lifts you up to the air,");
                Thread.Sleep(2000);
                Console.WriteLine("\tspins you around and tosses you like a ragdoll towards a huge rock..");
                Thread.Sleep(2000);
                Console.WriteLine("\tThings are not looking that good for you, buddy..");
                Check.PressEnter();

                Console.WriteLine("\tYou suddenly get a slight chance to escape if you start to run now!!");
                Thread.Sleep(2000);
                Console.WriteLine("\tDo you want to use the opportunity? y/n");

                var userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    RunAway(player, monster);
                    Visual.WanderingAround();
                    return;
                }
                else if (userInput == "n")
                {
                    ContinueFight(monster, player, damageToPlayer, damageToMonster, moreDamageToMonster);
                    Check.PressEnter();
                }
            }
        }

        private static void RunAway(Player player, Monster monster) //efter scenario 2 om spelaren väljer att fly
        {
            Visual.ChangeToMagenta();

            Console.WriteLine("\tYou start to run away like your life depends on it...  ");
            Check.PressEnter();

            Console.WriteLine($"\tAfter a looong and exhausting escape you finally seem to have lost {monster.Name} chasing you");
            Check.PressEnter();

            Console.WriteLine("\tOh damn! While you were sprinting like crazy you seem to have dropped your bag of gold :(");

            Console.WriteLine("\tTotally 10 gold peaces has been lost!");
            var goldDropped = 10;
            player.Gold -= goldDropped;
            Check.PressEnter();

            Console.WriteLine("\tBut it's too risky to go back now.. So you decide to continue the adventure.");
            Check.PressEnter();
            Console.ResetColor();
        }

        private static void ContinueFight(Monster monster, Player player, int damageToPlayer, int damageToMonster, int moreDamageToMonster) //efter scenario 2 om spelaren väljer att fortsätta
        {
            Visual.ChangeToMagenta();
            Console.WriteLine($"\tThere's no escaping now! Even though your whole body is on fire,");
            Console.Write($"\tYou take few surprisingly quick steps and swing your sword towards {monster.Name} and succeed in hitting it!");
            Check.PressEnter();

            Console.WriteLine($"\t{monster.Name} loses {damageToMonster} hp!");
            monster.Hp -= damageToMonster;
            Check.PressEnter();

            Console.WriteLine($"\tNow you got some new energy hit the monster to the leg! It howls of pain and loses {moreDamageToMonster} hp!");
            monster.Hp -= moreDamageToMonster;
            Check.PressEnter();

            Console.WriteLine("\tThe monster rages towards you but loses it's balance! Still somehow it manages to hit you!");
            Console.WriteLine($"\tYou lose {damageToPlayer} hp");
            player.Hp -= damageToPlayer;

            Console.WriteLine("\tBefore the monster gets up, you get your chance to give a powerful hit!");
            Console.WriteLine($"\tThe monster loses {moreDamageToMonster*2} hp!");
            monster.Hp -= moreDamageToMonster;
            Console.ResetColor(); 
        }


        //--------------------tredje scenario------------------------------------------------------------------ 

        public static void MonsterWantsGold(Player player, Monster monster)
        {
            while(monster.Hp>=0)
            {
                Console.WriteLine("You see a big rock ahead of you. Could you ");
                
            }
        }
            
    }
}