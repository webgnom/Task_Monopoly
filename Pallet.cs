using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Monopoly
{
    internal class Pallet : Cargo
    {
        public override double Weight => _Boxes.Sum(box => box.Weight) + 30; // Вес паллеты включает в себя вес всех коробок на паллете плюс вес самой паллеты (30 кг).
        public override double Volume => (Weight * Length * Height) + _Boxes.Sum(box => box.Volume); // Объём паллеты включает в себя вес паллеты, длину и высоту, а также объём всех коробок на паллете.

        public DateTime? Date_Expiration => (!_Boxes.Any()) ? null : _Boxes.Min(dr => dr.Date_Expiration)?.Date; // Возвращает минимальную дату истечения срока годности среди всех коробок на паллете, или null, если коробок нет.

        private readonly List<Box> _Boxes;

        public Pallet(int Width, int Length, int Height) : base(Width, Length, Height)
        {
            _Boxes = new List<Box>(); // Создаем лист для отдельного паллета
        }

        /// <summary> Прикрепить к палете коробку с проверкой</summary>
        /// <remarks> Пока не используется, сейчас в задумке хочу реализовать клон этого метода в Box'e</remarks>
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
