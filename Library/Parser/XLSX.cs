using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;

namespace Library.Parser
{
    public class XLSX : Parser
    {
        public void SetToFile(string path, Delegate methods)
        {
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
            ex.Visible = true;
            ex.SheetsInNewWorkbook = 1;
            Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            ex.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)workBook.Sheets[1]; ;

            
            string text = string.Empty;
            var delegates = methods.GetInvocationList();
            string[][] matrix;
            foreach (var item in delegates)
            {

                text += ((ForExecution)item)();
                string[] strings = text.Split('\n');
                matrix = new string[strings.Length][];
                for (int i = 0; i < strings.Length; i++)
                {
                    matrix[i] = strings[i].Split(';');
                }

                for (int i = 1; i <= strings.Length; i++)
                {
                    for (int j = 1; j < matrix[0].Length; j++)
                    {
                        sheet.Cells[i, j] = matrix[i][j];
                    }
                }

            }
            workBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            workBook.Close();
            ex.Quit();
        }
    }
}
