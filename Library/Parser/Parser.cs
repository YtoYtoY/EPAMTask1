using Library.DataBase.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Parser
{
    /// <summary>
    /// Delegate for reports without parameters
    /// </summary>
    /// <returns>Returning a dictionary for output to the report</returns>
    public delegate IDictionary<string, IEnumerable<Books>> ForExecutionEmpty();

    /// <summary>
    /// Delegate for reports with period parameters
    /// </summary>
    /// <param name="first">Beginning of period</param>
    /// <param name="last">End of period</param>
    /// <returns>Returning a dictionary for output to the report</returns>
    public delegate IDictionary<string, IEnumerable<Books>> ForExecutionDate(DateTime first, DateTime last);

    /// <summary>
    /// An interface for saving delegate information to various files
    /// </summary>
    public interface Parser
    {
        /// <summary>
        /// Method for saving delegate information to various files
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="empty">Delegate for reports without parameters</param>
        /// <param name="date">Delegate for reports with period parameters</param>
        /// <param name="first">Beginning of period</param>
        /// <param name="last">End of period</param>
        void SetToFile(string path, ForExecutionEmpty empty, ForExecutionDate date, DateTime first, DateTime last);

    }

}
