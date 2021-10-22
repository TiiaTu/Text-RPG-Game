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
            bool gameOn = true;
            
            while(gameOn)
            {
                ShowMainMenu();
            }
        }

        private static void ShowMainMenu()
        {
            Console.Write("Enter your username: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var username = Console.ReadLine().ToString();
            Console.ResetColor();
         
            Console.WriteLine("\n 1. Go adventuring");
            Console.WriteLine(" 2. Show details about your character");
            Console.WriteLine(" 3. Exit Game\n");
            Console.Write(">> ");
            
            int menuChoise=0;
            var input = int.TryParse(Console.ReadLine(), out menuChoise);

            switch (menuChoise)
            {
                case 1: break;
                case 2: break;
                case 3: Environment.Exit(0); break;
                    
                default:
                    break;
            }
        }

        public static void Attack()
        {
            Random random = new Random();
            //int strenghtLost = random.Next(, )
        }

        public static void MainHeader()
        {
            Console.WriteLine("╒═══════════════════════════════╕");
            Console.WriteLine("╞          -THE GAME-           ╡ ");
            Console.WriteLine("╘═══════════════════════════════╛");
        }
    }
}
