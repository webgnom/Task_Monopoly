using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Monopoly
{
    internal class Box : Cargo
    {
        private DateTime? _Date_Expiration;
        public override DateTime? Date_Expiration // Дата окончания срока годности
        { 
            get
            {
                if (_Date_Expiration.HasValue)
                {
                    return _Date_Expiration.Value.Date; // or .ToShortDateString
                }
                if (_Date_Production.HasValue)
                {
                    return _Date_Production.Value.AddDays(100).Date;
                }
                throw new InvalidOperationException("Срок годности или дата производства не указаны.");
            }
            set { _Date_Expiration = value; }
        } 
        
        private DateTime? _Date_Production; // Дата производства
        public DateTime? Date_Production
        {
            get { return _Date_Production.Value.Date; }
            set { _Date_Production = value; }
        }
        public double Pallet { get; set; }

        //public Box() { }

        public Box(double Width, double Length, double Height, double Weight, DateTime? Date_Expiration, DateTime? Date_Production, double Pallet) : base(Width, Length, Height)
        {
            if (!Date_Expiration.HasValue && !Date_Production.HasValue)
            {
                throw new ArgumentException("Необходимо указать либо срок годности, либо дату производства.");
            }
            this.Date_Production = Date_Production?.Date;
            this.Date_Expiration = Date_Expiration?.Date;
            this.Weight = Weight;
            this.Pallet = Pallet;


        }

        /// <summary> Положить в палету </summary>
        //public void PutInPallet(Pallet pallet)
        //{
        //    if (this.Width < pallet.Width || this.Length < pallet.Length)
        //    {
        //        Console.WriteLine($"Коробка ID: {this.ID.ToString()} не может быть добавлена на паллету ID: {Id.ToString()}. Размеры коробки ({this.Width}x{this.Length}) превышают размеры паллеты ({pallet.Width}x{pallet.Length}).");
        //        //throw new ArgumentException($"Коробка ID: {this.ID.ToString()} не может быть добавлена на паллету ID: {Id.ToString()}. Размеры коробки ({this.Width}x{this.Length}) превышают размеры паллеты ({pallet.Width}x{pallet.Length}).");
        //    }
        //    pallet._Boxes.Add(box);
        //}
    }
}
