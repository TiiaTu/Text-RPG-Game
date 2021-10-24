using System;

namespace Game_Tiia
{
    class Program
    {
        int strenght;
        int toughness;

        static void Main(string[] args)
        {
            MainHeader();
            Player player = new Player();
            
            AskForUsername();           
            player.Name= Console.ReadLine().ToString();
            Console.ResetColor();

            bool gameOn = true;

            while (gameOn)
            {                             
                Console.WriteLine("\n 1. Go adventuring");
                Console.WriteLine(" 2. Show details about your character");
                Console.WriteLine(" 3. Exit Game\n");
                Console.Write(">> ");

                int menuChoise = 0;
                //Console.ForegroundColor = ConsoleColor.Cyan;
                var input = int.TryParse(Console.ReadLine(), out menuChoise);
                //Console.ResetColor();

                switch (menuChoise)
                {
                    case 1: Adventure.WhileOnAdventure(); break;
                    case 2: ShowDetails(player.Name); break;
                    case 3: Environment.Exit(0); break;

                    default:
                        break;
                }
            }
        }

        public static void MainHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╒═══════════════════════════════╕");
            Console.WriteLine("╞          -THE GAME-           ╡ ");
            Console.WriteLine("╘═══════════════════════════════╛");
            Console.ResetColor();
        }

        public static void AskForUsername() //Frågar om användarnamnet
        {
            Console.Write("Enter your username: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        private static void ShowDetails(string username)
        {
            Console.WriteLine("═════════════════════════");
            Console.WriteLine($"Name:       {username}");
            Console.WriteLine($"Level:      "); //TODO: lägg till level här
            Console.WriteLine($"HP:      /200"); //TODO: lägg till hp
            Console.WriteLine($"Exp:     /100");
            Console.WriteLine($"Gold:      ");
            Console.WriteLine($"Strenght:  ");
            Console.WriteLine($"Toughness: ");
            Console.WriteLine("═════════════════════════");
            Console.WriteLine("Press any key to go back to MENU");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Attack()
        {
            Random random = new Random();
            //int strenghtLost = random.Next(, )
        }

        
    }
}
