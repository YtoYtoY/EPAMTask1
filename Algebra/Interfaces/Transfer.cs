using Algebra.SLAE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Interfaces
{
    public interface Transfer
    {
        /// <summary>
        /// The method chosen to solve the equation
        /// </summary>
        SolveMethod CurrentMethod { get; set; }

        /// <summary>
        /// Method for connecting a client
        /// </summary>
        void Connect();

    }
}
