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
        public double Width { get; set; } // Ширина
        public double Length { get; set; } // Длина (Глубина)
        public double Height { get; set; } // Высота
        public virtual double Volume => Width * Length * Height; // Объём
        public virtual double Weight { get; set; } // Вес
        public virtual DateTime? Date_Expiration { get; set; } // Дата окончания срока годности

        protected Cargo(double Width, double Length, double Height)
        {
            ID = Guid.NewGuid();
            this.Width = Width;
            this.Length = Length;
            this.Height = Height;
        }
    }
}
