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
                Check.PressEnter();
                Console.Clear();

                Visual.ChangeToMagenta();
                Console.WriteLine("\tWhile the monster is down on the ground, you jump over it to finish the fight");
                Check.PressEnter();

                Visual.ChangeToMagenta();
                Console.WriteLine("\tBut it turns around at the exact same moment and kicks you hard so that you fly high up to the air!");
                Check.PressEnter();
                Console.WriteLine($"\tThe power of the kick makes you to drop your sword..");
                Check.PressEnter();
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
                
                Check.PressEnter();
                MagentaText($"\tYou draw your sword and run towards {monster.Name}.. but you miss!");
                Check.PressEnter();

                CyanText($"\tThis seems to give the monster even more energy and before you realise it,");
                CyanText("\tyou get punched right in to the chest!");
                Check.PressEnter();

                MagentaText($"\tThe punch catches you complitely off guard and thrusts you to the ground,");
                MagentaText($"\tYou lose {damageToPlayer} hp");
                player.Hp -= damageToPlayer;
                Check.PressEnter();

                CyanText($"\tBefore you have time to get up {monster.Name} lifts you up to the air,");
                Check.PressEnter();
                CyanText("\tspins you around and tosses you like a ragdoll towards a huge rock..");
                Check.PressEnter();
                MagentaText("\tThings are not looking that good for you, buddy..");
                Check.PressEnter();

                CyanText("\tYou suddenly get a slight chance to escape if you start to run now!!");               
                CyanText("\tDo you want to use the opportunity? y/n");

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
            MagentaText("\tYou start to run away like your life depends on it...  ");
            Check.PressEnter();

            CyanText($"\tAfter a looong and exhausting escape you finally seem to have lost {monster.Name} chasing you");
            Check.PressEnter();

            MagentaText("\tOh damn! While you were sprinting like crazy you seem to have dropped your bag of gold :(");

            MagentaText("\tTotally 10 gold peaces has been lost!");
            var goldDropped = 10;
            player.Gold -= goldDropped;
            Check.PressEnter();

            CyanText("\tBut it's too risky to go back now.. So you decide to continue the adventure.");
            Check.PressEnter();
        }

        private static void ContinueFight(Monster monster, Player player, int damageToPlayer, int damageToMonster, int moreDamageToMonster) //efter scenario 2 om spelaren väljer att fortsätta
        {
            MagentaText($"\tThere's no escaping now! Even though your whole body is on fire,");
            MagentaText($"\tYou take few surprisingly quick steps and swing your sword towards {monster.Name} and succeed in hitting it!");
            Check.PressEnter();

            MagentaText($"\t{monster.Name} loses {damageToMonster} hp!");
            monster.Hp -= damageToMonster;
            Check.PressEnter();

            CyanText($"\tNow you got some new energy hit the monster to the leg! It howls of pain and loses {moreDamageToMonster} hp!");
            monster.Hp -= moreDamageToMonster;
            Check.PressEnter();

            MagentaText("\tThe monster rages towards you but loses it's balance! Still somehow it manages to hit you!");
            MagentaText($"\tYou lose {damageToPlayer} hp");
            player.Hp -= damageToPlayer;

            CyanText("\tBefore the monster gets up, you get your chance to give a powerful hit!");
            CyanText($"\tThe monster loses {moreDamageToMonster*2} hp!");
            monster.Hp -= moreDamageToMonster;
             
        }

        //--------------------tredje scenario------------------------------------------------------------------ 
        public static void FightOptions(Player player, Monster monster)
        {
            while(monster.Hp>=0)
            {
                Console.WriteLine("Suddenly the forest gets much thicker and you start to get weird vibes...");
                Check.PressEnter();
                Console.Write("The ground starts to shake and you start to hear loud noises..");
                Console.WriteLine("just like drumbeats");
                Check.PressEnter();
                Console.WriteLine("You walk towards the sound and find a lonely Shaman dansing around the fire with his drum..");
                Console.WriteLine("What do you choose to do?");
                Menu.FightMenu();

                var userChoise = 0;
                int.TryParse(Console.ReadLine(), out userChoise);

                switch (userChoise)
                {
                    case 1: RunAway(); break;
                    case 2: ApproachShaman(); break;
                    case 3: AttackShaman(player); break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        private static void AttackShaman(Player player)
        {
            CyanText("You're one daring adventurer... you choose to attack the Shaman");
            Check.PressEnter();
            CyanText("You grab your sword and get ready for the attack...");
            Visual.PointPoint();
            Console.WriteLine("###sjddl...---<<lkof??39r***#kawfe8ww/#)...");
            Visual.PointPoint();
            Console.Write("&#93b0#)R#%Äa>>g _what_ ÄW-r<w _is_ aA)(wf  _happening?_ wr93q");
            Visual.PointPoint();
            Console.Clear();
            MagentaText("... WHAT on earth was THAT?? You look around ");
            Visual.PointPoint();
            CyanText("Somehow you have gotten back to the beginning of the forest.. BUT HOW?");

            MagentaText("Then it hits you... maybe you shouldn't have tried to attack the Shaman...");
            Check.PressEnter();
            
            CyanText("Now you have lost all your exp.. oops :/ ");
            player.Exp = 0;
            
        }

        private static void ApproachShaman()
        {
            Console.Clear();
            CyanText("As you start to approach the Shaman, he all of a sudden drops his drum, \nturns around and stares at you with his deep black eyes! ");
            CyanText("He signs you to come closer..");
            Visual.PointPoint();
            Check.PressEnter();
            MagentaText("You feel shivers go down your spine and think all the alternative ways to escape");
            Check.PressEnter();
            CyanText("As you come closer you can see that he is fairly irritated after you walked in and interrupted his.. \n..whatever he was doing.. some ritual I guess?");
            Check.PressEnter();
            CyanText("BUT.. he shows his gratitude towards you, that you didn't decide to attack him... and steal his gold ");
            Check.PressEnter();
            
            MagentaText("You wonder how the heck he knew that and feel bad for even thinking about that...");
            Check.PressEnter();
            MagentaText("You don't want to irritate him any more so you decide to give him 2 pieces of gold");
            Check.PressEnter();
            CyanText("He thanks you and offers to cast a toughness spell over you (+ 1 toughness)");
            Check.PressEnter();
            MagentaText("You accept the spell and get 1 toughness point! Then you go off to continue your adventure after this rather..\n..weird.. encounter");
            Visual.WanderingAround();

        }

        private static void MagentaText(string text)
        {
            Visual.ChangeToMagenta();
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void CyanText(string text)
        {
            Visual.ChangeToCyan();
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void RunAway()
        {
            Console.Clear();
            Console.WriteLine("You choose to run away and continue the adventure");
            Visual.WanderingAround();
        }
    }
}