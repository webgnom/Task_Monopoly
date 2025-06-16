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

            // Для личного удобства
            DataColumnCollection dataColumnCollection = dt.Columns;
            DataColumn dataColumn_Name = dt.Columns["Name_Box"];
            DataColumn dataColumn_Width = dt.Columns["Width_Box"];
            DataColumn dataColumn_Length = dt.Columns["Length_Box"];
            DataColumn dataColumn_Height = dt.Columns["Height_Box"];
            DataColumn dataColumn_Date_Production = dt.Columns["Date_Production_Box"];
            DataColumn dataColumn_Date_Expiration = dt.Columns["Date_Expiration_Box"];
            DataColumn dataColumn_Weight = dt.Columns["Weight_Box"];
            DataColumn dataColumn_Pallet = dt.Columns["Pallet_Box"];

            //int int1 = 45794;
            //DateTime dateTime1 = Convert.ToDateTime(int1);
            //DateTime dateTime2 = Convert.ToDateTime(dt.Rows[5][0]);

            List<Box> list_Box_test = dt
                .AsEnumerable()
                .Select(dr =>
                    new Box()
                    {
                        Date_Production = dr["Date_Production_Box"] as DateTime?,
                        //Date_Production = Convert.ToDateTime(dr["Date_Production_Box"]),
                        //Date_Production = dr.Field<DateTime?>("Date_Production_Box"),
                    }
                )
                .ToList()
            ;
            var query = dt
                .AsEnumerable()
                .Select(dr =>
                    new Box()
                    {
                        //Width = Convert.ToInt32(dr["Width_Box"]),
                        //Length = Convert.ToInt32(dr["Length_Box"]),
                        //Height = Convert.ToInt32(dr["Height_Box"]),
                        Date_Production = Convert.ToDateTime(dr["Date_Production_Box"]),

                        //Date_Production = !(dr["Date_Production_Box"] is DateTime) ? null : Convert.ToDateTime(dr["Date_Production_Box"]) ,
                        ////Date_Production = dr.Field<DateTime?>("Date_Production_Box"),

                        ////Date_Expiration = Convert.ToDateTime(dr["Date_Expiration_Box"]),
                        ////Date_Expiration = Convert.ToDateTime(dr["Date_Expiration_Box"]),
                        //Weight = Convert.ToInt32(dr["Weight_Box"]),
                        //Pallet = Convert.ToInt32(dr["Pallet_Box"]),

                        Width = dr.Field<int>("Width_Box"),
                        Length = dr.Field<int>("Length_Box"),
                        Height = dr.Field<int>("Height_Box"),
                        //Date_Production = dr.Field<DateTime>("Date_Production_Box"),
                        //Date_Expiration = dr.Field<DateTime>("Date_Expiration_Box"),
                        Weight = dr.Field<int>("Weight_Box"),
                        Pallet = dr.Field<int>("Pallet_Box"),
                    }
                )
            ;
            List<Box> list_Box = query.ToList();

            //Console.WriteLine($"ID = {list_Box[0].ID,-4}, Width = {list_Box[0].Width,-4}, Length = {list_Box[0].Length,-4}, Height = {list_Box[0].Height,-4}, Date_Expiration = {list_Box[0]?.Date_Expiration,-12}, Date_Production = {list_Box[0]?.Date_Production,-12}, Weight = {list_Box[0].Weight,-4}, Pallet = {list_Box[0].Pallet,-4} ");

            Box box = new Box();
            box.Weight = 1;


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
