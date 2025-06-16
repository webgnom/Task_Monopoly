using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Monopoly
{
    internal class Pallet : Cargo
    {
        public override int Weight { get; set; } // Переопределение свойства Weight для Pallet
        public override int Volume 
        { 
            get 
            {
                return Volume;
            } 
        }

    }
}
