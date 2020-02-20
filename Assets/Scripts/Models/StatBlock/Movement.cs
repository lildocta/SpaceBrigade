using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.StatBlock
{
    public class Movement
    {
        private float RotateSpeed { get; set; }
        private float Radius { get; set; }

        public Movement(int heiarchy)
        {

            switch (heiarchy)
            {
                case 1:
                    RotateSpeed = 1F;
                    Radius = 3.14F;
                    break;
                case 2:
                    RotateSpeed = .75F;
                    Radius = 1F;
                    break;
                default:
                    Console.WriteLine("The code is heckin broked dawg");
                    break;
            }
        }
    }
}
