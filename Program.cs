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

            // пока не используется 
            DataColumnCollection dataColumnCollection = dt.Columns;
            DataColumn dataColumn_Name = dt.Columns["Name_Box"];
            DataColumn dataColumn_Width = dt.Columns["Width_Box"];
            DataColumn dataColumn_Length = dt.Columns["Length_Box"];
            DataColumn dataColumn_Height = dt.Columns["Height_Box"];
            DataColumn dataColumn_Date_Production = dt.Columns["Date_Production_Box"];
            DataColumn dataColumn_Date_Expiration = dt.Columns["Date_Expiration_Box"];
            DataColumn dataColumn_Weight = dt.Columns["Weight_Box"];
            DataColumn dataColumn_Pallet = dt.Columns["Pallet_Box"];

            foreach (DataRow dr in dt.Rows)
            {
                var val = dr["Length_Box"];
                Console.WriteLine($"{val} - {val?.GetType()?.Name ?? "null"}");
            }

            // тест 
            List<Box> List_test = new List<Box>();
            foreach (DataRow dr in dt.Rows) 
            {
                Box current_Box = new Box
                (
                    Width: dr.Field<double>("Width_Box"),
                    Length: dr.Field<double>("Length_Box"),
                    Height: dr.Field<double>("Height_Box"),
                    Weight: dr.Field<double>("Weight_Box"),
                    Date_Production: dr.Field<DateTime?>("Date_Production_Box"),
                    Date_Expiration: dr.Field<DateTime?>("Date_Expiration_Box"),
                    Pallet: dr.Field<double>("Pallet_Box")
                    //Width: 1,
                    //Length: dr.Field<int>("Length_Box"),
                    //Height: 1,
                    //Weight: 1,
                    //Date_Production: dr.Field<DateTime?>("Date_Production_Box"),
                    //Date_Expiration: dr.Field<DateTime?>("Date_Expiration_Box"),
                    ////Date_Production: DateTime.Parse("17.05.2025"),
                    ////Date_Expiration: null,
                    //Pallet: 1
                );
                List_test.Add(current_Box);

            }

            //Тест
            var query = dt
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
                    //{
                    //    //Width = Convert.ToInt32(dr["Width_Box"]),
                    //    //Length = Convert.ToInt32(dr["Length_Box"]),
                    //    //Height = Convert.ToInt32(dr["Height_Box"]),
                        
                    //    //Date_Production = Convert.ToDateTime(dr["Date_Production_Box"]),
                    //    //Date_Production = !(dr["Date_Production_Box"] is DateTime) ? null : Convert.ToDateTime(dr["Date_Production_Box"]) ,
                    //    //Date_Production = dr.Field<DateTime?>("Date_Production_Box"),

                    //    ////Date_Expiration = Convert.ToDateTime(dr["Date_Expiration_Box"]),
                    //    ////Date_Expiration = Convert.ToDateTime(dr["Date_Expiration_Box"]),
                        
                    //    //Weight = Convert.ToInt32(dr["Weight_Box"]),
                    //    //Pallet = Convert.ToInt32(dr["Pallet_Box"]),

                    //    Width = dr.Field<int>("Width_Box"),
                    //    Length = dr.Field<int>("Length_Box"),
                    //    Height = dr.Field<int>("Height_Box"),
                    //    Weight = dr.Field<int>("Weight_Box"),
                    //    Date_Production = dr["Date_Production_Box"] as DateTime?,
                    //    Date_Expiration = dr["Date_Expiration_Box"] as DateTime?,
                    //    //Date_Production = dr.Field<DateTime>("Date_Production_Box"),
                    //    //Date_Expiration = dr.Field<DateTime>("Date_Expiration_Box"),
                    //    Pallet = dr.Field<int>("Pallet_Box"),
                    //}
                )
            ;
            List<Box> list_Box = query.ToList();

            ////Console.WriteLine($"ID = {list_Box[0].ID,-4}, Width = {list_Box[0].Width,-4}, Length = {list_Box[0].Length,-4}, Height = {list_Box[0].Height,-4}, Date_Expiration = {list_Box[0]?.Date_Expiration,-12}, Date_Production = {list_Box[0]?.Date_Production,-12}, Weight = {list_Box[0].Weight,-4}, Pallet = {list_Box[0].Pallet,-4} ");

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







            // Другое
            Box1 box1 = new Box1()
            {
                Width = 13,
                Height = 4,
                Length = 8
            };
           
            int V = box1.Volume;
        }
    }
}
