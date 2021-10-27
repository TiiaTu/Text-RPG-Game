using System;

namespace Game_Tiia
{
    public class Player : Entity
    {
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int Strenght { get; set; } = 5;
        public int Toughness { get; set; } = 0;
        public int Gold { get; set; } = 20;

        public static void GetGold()
        {
            
        }
    }
    
}
