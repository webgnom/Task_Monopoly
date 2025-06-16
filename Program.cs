using Microsoft.Office.Interop.Excel;
using System;
using Data = System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;
using System.Net.Mail;
using Microsoft.Vbe.Interop;

namespace Task_Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string pathExcel = Path.Combine(projectDir, @"Attachments\Data.xlsx");

            ReadExcel ReadExcel = new ReadExcel(pathExcel, 0);
            Data.DataTable dt = ReadExcel.GetTable();

            List<Box> list_Box = dt
                .AsEnumerable()
                .Select(dr =>
                    new Box(
                        Width: dr.Field<double>("Width_Box"),
                        Length: dr.Field<double>("Length_Box"),
                        Height: dr.Field<double>("Height_Box"),
                        Weight: dr.Field<double>("Weight_Box"),
                        Date_Production: dr.Field<DateTime?>("Date_Production_Box"),
                        Date_Expiration: dr.Field<DateTime?>("Date_Expiration_Box"),
                        Pallet: dr.Field<double>("Pallet_Box")
                    )
                )
                .ToList()
            ;


            //// Генерация прямо в приложении

            //// Создаем паллеты
            //Console.WriteLine("Создаем паллеты");
            //List<Pallet> pallets = new List<Pallet>()
            //{
            //    new Pallet(80, 120, 15),
            //    new Pallet(100, 120, 15),
            //    new Pallet(120, 120, 15),
            //};

            //// Создаем коробки
            //Console.WriteLine("\nСоздаем коробки");
            //List<Box> Boxes = new List<Box>()
            //{
            //    new Box(60, 40, 30, 12, Date_Expiration: DateTime.Today.AddDays(10), null, Pallet: 1), // Самый короткий срок годности 
            //    new Box(50, 30, 25, 10, Date_Expiration: DateTime.Today.AddDays(20), null, Pallet: 2),
            //    new Box(40, 25, 20, 7, Date_Expiration: DateTime.Today.AddDays(50), null, Pallet: 3),
            //    new Box(25, 18, 12, 4, Date_Expiration: DateTime.Today.AddDays(100), null, Pallet: 1), // Самый долгий срок годности
            //    new Box(70, 30, 40, 15, null, Date_Production: DateTime.Today.AddDays(-80), Pallet: 2),
            //    new Box(35, 22, 18, 6, null, Date_Production: DateTime.Today.AddDays(-30), Pallet: 3),
            //    new Box(30, 20, 15, 5, null, Date_Production: DateTime.Today.AddDays(-10), Pallet: 1),
            //    new Box(20, 15, 10, 3, null, Date_Production: DateTime.Today.AddDays(-5), Pallet: 2),
            //    new Box(110, 50, 70, 20, null, Date_Production: DateTime.Today.AddDays(-1), Pallet: 3),

            //};




        }
    }
}
