using Microsoft.Office.Interop.Excel;  
using System;
using System.Data;
using Data = System.Data;


namespace Task_Monopoly
{
    /// <summary>
    /// Mini Excel Reader...
    /// </summary>
    internal class ReadExcel
    {
        private string Path = string.Empty;
        private Application Application = new Application();
        private Workbook Workbook;
        private Worksheet Worksheet;

        public ReadExcel(string Path) 
        { 
            this.Path = Path; 
        }
        public ReadExcel(string Path, int indexSheet) : this(Path)
        {
            this.Workbook = Application.Workbooks.Open(Path);
            this.Worksheet = Workbook.Worksheets[indexSheet + 1];
        }
        public ReadExcel(string Path, string nameSheet) : this(Path)
        {
            this.Workbook = Application.Workbooks.Open(Path);
            this.Worksheet = Workbook.Worksheets[nameSheet];
        }

        public string Cell(int Row, int Column)
        {
            Row++;
            Column++;
            return this.Worksheet.Cells[Row, Column].Value ?? string.Empty;
        }

        //public Object[,] Range(string Range)
        //{
        //    return this.Worksheet.Range[Range].Value ?? string.Empty;
        //}

        //public string Range1Cell(string Range)
        //{
        //    return this.Worksheet.Range[Range].Value ?? string.Empty;
        //}

        //public Range UsedRange()
        //{
        //    return this.Worksheet.UsedRange;
        //}

        /// <summary>
        /// Read UsedRange from sheet
        /// </summary>
        /// <returns>DataTable</returns>
        public Data.DataTable GetTable()
        {
            Range usedRange = this.Worksheet.UsedRange;
            Data.DataTable dt = new Data.DataTable();
            int countRow = usedRange.Rows.Count;
            int countColumn = usedRange.Columns.Count;

            // Читаем заголовки из первой строки
            for (int column = 1; column <= countColumn; column++)
            {
                string colName = Convert.ToString((usedRange.Cells[1, column]).Value);
                if (string.IsNullOrWhiteSpace(colName))
                    colName = $"column{column}";

                dt.Columns.Add(colName, typeof(object));

                //Попытка присвоить тип данных (Что в голову не приходит все дерьмово выглядит, даже если нафигачить через регулярки)
                //object cellValue = (usedRange.Cells[2, column])?.Value; 
                // далее проблема в null, если в ячейке пусто
                //Type cellType = cellValue != null ? cellValue.GetType() : typeof(string); // или typeof(object) 

                //DataColumn dataColumn = dt.Columns.Add(colName);
                //dataColumn.DataType = cellType;
            }

            // Читаем данные начиная со второй строки
            for (int row = 2; row <= countRow; row++)
            {
                DataRow dataRow = dt.NewRow();
                for (int column = 1; column <= countColumn; column++)
                {
                    object cellValue = (usedRange.Cells[row, column])?.Value;
                    if (cellValue is DateTime dateTime_Value)
                        dataRow[column - 1] = dateTime_Value;
                    else 
                        dataRow[column - 1] = cellValue;
                }
                dt.Rows.Add(dataRow);
            }

            // Освобождаем ресурсы
            this.Workbook.Close(false);
            this.Application.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(usedRange);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Application);

            return dt;
        }

    }
}
