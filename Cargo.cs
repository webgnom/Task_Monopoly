using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Monopoly
{
    internal class Cargo
    {
        
        public Guid ID { get; }
        public int Width { get; set; } // Ширина
        public int Length { get; set; } // Длина (Глубина)
        public int Height { get; set; } // Высота
        public virtual int Volume => Width * Length * Height; // Объём
        public virtual int Weight { get; set; } // Вес
        public virtual DateTime? Date_Expiration { get; set; } // Дата окончания срока годности

        protected Cargo(int Width, int Length, int Height)
        {
            ID = Guid.NewGuid();
            this.Width = Width;
            this.Length = Length;
            this.Height = Height;
        }
    }
}
