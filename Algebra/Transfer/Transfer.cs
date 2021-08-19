using Algebra.Classes;
using Algebra.SLAE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    public abstract class Transfer
    {
        public TcpListener server = new TcpListener(Constants.localAddress, Constants.port);

        public delegate double[] TrySolveDelegate(double[][] leftPart, double[] rightPart);

        public SolveMethod CurrentMethod { get; set; }
        public abstract void Connect();

        public abstract void GetAndSolve(NetworkStream stream);
        
    }
}
