using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Monopoly
{
    internal class Pallet : Cargo
    {
        public override double Weight { get; set; } // Переопределение свойства Weight для Pallet
        public override double Volume 
        { 
            get 
            {
                return Volume;
            } 
        }

        private readonly List<Box> _Boxes;

        public Pallet(int Width, int Length, int Height) : base(Width, Length, Height)
        {
            _Boxes = new List<Box>(); // Создаем лист для отдельного паллета
        }

        // Ручное добавление коробки
        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Length > Length)
            {
                Console.WriteLine($"Коробка ID: {box.ID.ToString()} не может быть добавлена на паллету ID: {this.ID.ToString()}. Размеры коробки ({box.Width}x{box.Length}) превышают размеры паллеты ({Width}x{Length}).");
                //throw new ArgumentException($"Коробка ID: {box.ID.ToString()} не может быть добавлена на паллету ID: {this.ID.ToString()}. Размеры коробки ({box.Width}x{box.Length}) превышают размеры паллеты ({Width}x{Length}).");
            }
            _Boxes.Add(box);
        }

    }
}
