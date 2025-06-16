using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Monopoly
{
    internal class Box1
    {
        // Допустим что все данные прилетают правильные
        public int ID { get; set; }
        public int Width { get; set; } // Ширина
        public int Length { get; set; } // Длина (Глубина)
        public int Height { get; set; } // Высота
        public int Volume => Width * Length * Height; // Объём
        public int Weight { get; set; } // Вес
        public DateTime Date_Expiration { get; set; } // Дата окончания срока годности
        public DateTime Date_Production { get; set; } // Дата производства

        public Box1() { }
        public Box1(int ID, int Width, int Length, int Height, int Weight, DateTime Date_Production)
        {
            this.ID = ID;
            this.Width = Width;
            this.Length = Length;
            this.Height = Height;
            this.Weight = Weight;
            this.Date_Production = Date_Production;
        }
        public void Print() => Console.WriteLine($"Имя: {ID}  Возраст: {Width} и тд");
    }
}
