using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Tiia
{
    public class Entity
    {
        public string Name { get; set; } = "";

        private int hp = 100;
        public int Hp //TODO: kolla att dethär blir rätt
        {
            get => hp;
            set
            {
                if (hp<= 0)
                {
                    Console.WriteLine("GAME OVER!");
                }
            }
        }
    }
}
