using System;

namespace Game_Tiia
{
    internal class FightScenario
    {
        //----------------------första scenario------------------------------------------------------
        public static void BasicFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            Visual.ChangeToMagenta();
            Check.PressEnter();
            Console.Write($"\tAAAH! The monster rages towards you and hits you! You lose {damageTaken} hp");
            player.Hp -= (damageTaken - player.Toughness);
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\n\tYou swing your sword and slash the monster! The monster loses {damageGiven} hp");
            monster.Hp -= (damageGiven + player.Strenght);
            Check.PressEnter();

            Visual.ChangeToMagenta();
            Console.WriteLine($"\tBut the monster is fast and you get hit again, this time you lose {damageTaken2} hp");
            player.Hp -= (damageTaken2 - player.Toughness);
            Check.PressEnter();

            Visual.ChangeToCyan();
            Console.WriteLine($"\tYou survive the hit, make a skillfull maneuver and succeed in hitting the monster again. \n\tThe monster loses {damageGiven2} hp ");
            monster.Hp -= damageGiven2 + player.Strenght;
            Console.ResetColor();
            Check.PressEnter();
        }

        //-------------------------andra scenario----------------------------------------------------------
        public static void LongerFight(Player player, Monster monster, int damageGiven, int damageGiven2, int damageTaken, int damageTaken2)
        {
            var damageToPlayer = (damageTaken - player.Toughness);
            var damageToMonster = (damageGiven + player.Strenght);
            var damageToMonster2 = (damageGiven2 + player.Strenght);

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

            Console.WriteLine($"\tBefore you have time to get up {monster.Name} lifts you up to the air");
            Console.WriteLine("\tand tosses you like a ragdoll..");
            Console.WriteLine("\tThings are not looking good for you right now..");
            Check.PressEnter();

            Console.WriteLine("\tYou suddenly get a slight chance to escape if you start to run now!!");
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
                ContinueFight(monster, damageToMonster, damageToMonster2);
                Check.PressEnter();
            }
        }

        private static void RunAway(Player player, Monster monster) //efter scenario 2 om spelaren väljer att fly
        {
            Visual.ChangeToMagenta();

            Console.WriteLine("You start to run away like your life depends on it... and it kinda does. ");
            Check.PressEnter();

            Console.WriteLine($"After a looong and exhausting escape you finally seem to have lost {monster.Name} chasing you");
            Check.PressEnter();

            Console.WriteLine("But oh no! While you were sprinting like crazy you seem to have dropped your bag of gold :(");

            Console.WriteLine("Totally 10 gold peaces has been lost!");
            var goldDropped = 10;
            player.Gold -= goldDropped;
            Check.PressEnter();

            Console.WriteLine("It's too risky to go back now.. So you decide to continue the adventure.");
            Check.PressEnter();
            Console.ResetColor();
        }

        private static void ContinueFight(Monster monster, int damageToMonster, int damageToMonster2) //efter scenario 2 om spelaren väljer att fortsätta
        {
            Visual.ChangeToMagenta();
            Console.WriteLine($"\tThere's no escaping now! Even though your whole body is on fire,");
            Console.Write($"\tyou take few surprisingly quick steps and swing your sword towards {monster.Name} and succeed in hitting it!");
            Check.PressEnter();

            Console.WriteLine($"\t{monster.Name} loses {damageToMonster} hp!");
            monster.Hp -= damageToMonster;
            Check.PressEnter();

            Console.WriteLine($"\tNow you got some new energy hit the monster to the leg! It howls of pain and loses {damageToMonster2} hp!");
            monster.Hp -= damageToMonster2;
            Check.PressEnter();

            Console.WriteLine("Before the monster gets up, you get your chance to finish it with one powerful hit!");
            monster.Hp = 0;
            Console.ResetColor();
        }

        //-----------------------tredje scenario---------------------------------------------------------
    }
}