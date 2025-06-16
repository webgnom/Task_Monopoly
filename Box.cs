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
        public int Pallet { get; set; }

        public Box() { }

        //public Box(int Width, int Length, int Height, int Weight, DateTime? Date_Expiration, DateTime? Date_Production) : base(Width, Length, Height)
        //{
        //    if (!Date_Expiration.HasValue && !Date_Production.HasValue)
        //    {
        //        throw new ArgumentException("Необходимо указать либо срок годности, либо дату производства.");
        //    }
        //    Date_Expiration = Date_Expiration?.Date; // Обрезаем время
        //    Date_Production = Date_Production?.Date; // Обрезаем время
        //    this.Weight = Weight;
        //}


    }
}
