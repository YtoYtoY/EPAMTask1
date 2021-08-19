using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.SLAE
{
    public abstract class SolveMethod
    {
        public event EventHandler GoToSolve;
        public double[] Answer { get; protected set; }
        protected double[][] LeftPart { get; }
        protected double[] RightPart { get; }
        public int N { get; }

        protected SolveMethod(double[][] leftPart, double[] rightPart)
        {
            LeftPart = leftPart;
            RightPart = rightPart;

            N = RightPart.GetLength(0);
            Answer = new double[N];
            if (LinearCheck(LeftPart, RightPart))
            {
                GoToSolve?.Invoke(this, new EventArgs());
            }
        }

        public bool LinearCheck(double[][] leftPart, double[] rightPart)
        {
            return (leftPart[0].Length == rightPart.Length);
        }

        public abstract void TrySolve(double[][] leftPart, IReadOnlyList<double> rightPart);

    }
}
