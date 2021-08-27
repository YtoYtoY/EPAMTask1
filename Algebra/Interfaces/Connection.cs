using Algebra.SLAE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Interfaces
{
    public interface Connection
    {
        SolveMethod CurrentMethod { get; set; }
        void Finish(Socket listener);
        void Start();
    }
}
