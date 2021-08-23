using Library.DataBase.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace Library.Parser
{
    /// <summary>
    /// Class for saving information to PDF file
    /// </summary>
    public class PDF : Parser
    {
        /// <summary>
        /// Method for saving delegate information to .docx and .pdf files
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="empty">Delegate for reports without parameters</param>
        /// <param name="date">Delegate for reports with period parameters</param>
        /// <param name="first">Beginning of period</param>
        /// <param name="last">End of period</param>
        public void SetToFile(string path, ForExecutionEmpty empty, ForExecutionDate date, DateTime first, DateTime last)
        {
            FileInfo _fileinfo;
            if (File.Exists(path))
                _fileinfo = new FileInfo(path);
            else
                throw new ArgumentException("File not found");

            Word.Application app = null;
            string text = string.Empty;

            try
            {
                
                var emptyMethods = empty.GetInvocationList();
                var dateMethods = date.GetInvocationList();

                foreach (var item in emptyMethods)
                {
                    IDictionary<string, IEnumerable<Books>> dict =
                        (IDictionary<string, IEnumerable<Books>>)item.DynamicInvoke();
                    text += WithdrawDictionary(dict, item);
                }

                text += "\n";
                foreach (var item in dateMethods)
                {
                    IDictionary<string, IEnumerable<Books>> dict =
                        (IDictionary<string, IEnumerable<Books>>)item.DynamicInvoke(first, last);
                    text += WithdrawDictionary(dict, item);
                }

                app = new Word.Application();
                Object file = _fileinfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);

                Word.Find find = app.Selection.Find;
                find.Text = "<DOC>"; // TODO: DOC - constant
                find.Replacement.Text = text;

                Object wrap = Word.WdFindWrap.wdFindContinue;
                Object replace = Word.WdReplace.wdReplaceAll;

                find.Execute(FindText: Type.Missing,
                    MatchCase: false,
                    MatchWholeWord: false,
                    MatchWildcards: false,
                    MatchSoundsLike: missing,
                    MatchAllWordForms: false,
                    Forward: true,
                    Wrap: wrap,
                    Format: false,
                    ReplaceWith: missing,
                    Replace: replace);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                app.ActiveDocument.SaveAs2(path, 16);
                app.ActiveDocument.SaveAs2(path, 17);
                app.ActiveDocument.Close();
                app.Quit();
            }

        }

        /// <summary>
        /// The method returns a list from the dictionary grouped into text
        /// </summary>
        /// <param name="dict">Dictonary parameter</param>
        /// <param name="item">Current method</param>
        /// <returns>Dictionary grouped into string</returns>
        private string WithdrawDictionary(IDictionary<string, IEnumerable<Books>> dict, Delegate item)
        {
            string result = string.Empty;
            result += item.Method.Name + "\n";

            foreach (var dictItem in dict)
            {
                result += dictItem.Key.ToString() + "\n";
                foreach (var book in dictItem.Value)
                {
                    result += book.ToString() + "\n";
                }
            }
            return result;
        }


    }
}
