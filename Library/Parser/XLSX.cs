using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Library.DataBase.ORM;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace Library.Parser
{
    /// <summary>
    /// Class for saving information to an Excel file
    /// </summary>
    public class XLSX : Parser
    {
        /// <summary>
        /// Method for saving delegate information to .xlsx files
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="empty">Delegate for reports without parameters</param>
        /// <param name="date">Delegate for reports with period parameters</param>
        /// <param name="first">Beginning of period</param>
        /// <param name="last">End of period</param>
        public void SetToFile(string path, ForExecutionEmpty empty, ForExecutionDate date, DateTime first, DateTime last)
        {
            Workbook m_workBook = null;
            Worksheet m_workSheet = null;
            Excel._Application m_app = null;

            try
            {
                m_app = new Excel.Application();
                m_app.Visible = false;
                m_app.UserControl = true;
                m_workBook = m_app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                m_workSheet = m_app.ActiveSheet as Worksheet;

                var emptyMethods = empty.GetInvocationList();
                var dateMethods = date.GetInvocationList();
                int index = 0;

                foreach (var item in emptyMethods)
                {
                    IDictionary<string, IEnumerable<Books>> dict =
                                (IDictionary<string, IEnumerable<Books>>)item.DynamicInvoke();

                    foreach (var cell in dict)
                    {
                        m_workSheet.Cells[index, 0] = cell.Key;
                        for (int i = 1; i < cell.Value.Count() + 1; i++)
                        {
                            m_workSheet.Cells[index, i] = cell.Value.ElementAt(i - 1);
                            index++;
                        }
                    }
                }

                foreach (var item in dateMethods)
                {
                    IDictionary<string, IEnumerable<Books>> dict =
                                (IDictionary<string, IEnumerable<Books>>)item.DynamicInvoke(first, last);

                    foreach (var cell in dict)
                    {
                        m_workSheet.Cells[index, 0] = cell.Key;
                        for (int i = 1; i < cell.Value.Count() + 1; i++)
                        {
                            m_workSheet.Cells[index, i] = cell.Value.ElementAt(i - 1);
                            index++;
                        }
                    }
                }
                m_workBook.SaveAs(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                m_workBook.Close(false, "", Type.Missing);
                m_app.Quit();

                m_workBook = null;
                m_workSheet = null;
                m_app = null;
                GC.Collect();
            }
        }
    }
}
