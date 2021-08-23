using Library.DataBase.ORM;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Parser
{
    /// <summary>
    /// A class for saving information to a text file
    /// </summary>
    public class TEXT : Parser
    {
        /// <summary>
        /// Method for saving delegate information to .txt files
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="empty">Delegate for reports without parameters</param>
        /// <param name="date">Delegate for reports with period parameters</param>
        /// <param name="first">Beginning of period</param>
        /// <param name="last">End of period</param>
        public void SetToFile(string path, ForExecutionEmpty empty, ForExecutionDate date, DateTime first, DateTime last)
        {

            string text = string.Empty;
            try
            {
                using (StreamWriter writer = File.CreateText(path))
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

                    writer.Write(text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
