using Algebra.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.SLAE
{
    /// <summary>
    /// Simple Iteration Method for solving SLAEs
    /// </summary>
    public class IterationMethod : SolveMethod
    {
        public IterationMethod(double[][] leftPart, double[] rightPart) : base(leftPart, rightPart)
        {
        }

        public IterationMethod()
        {
        }

        private bool Converge(ref double[] xk, ref double[] xkp)
        {
            int length = xk.GetLength(0);

            double norm = 0.0;
            for (int i = 0; i < length; i++)
            {
                norm += (xk[i] - xkp[i]) * (xk[i] - xkp[i]);
            }

            return Math.Sqrt(norm) < Constants.epsilonSlae;
        }
        public override void TrySolve(double[][] leftPart, IReadOnlyList<double> rightPart)
        {
            int length = leftPart.GetLength(0);
            double[] p = new double[length];
            double[] x = new double[length];
            

            double[][] alpha = new double[length][];
            double[] beta = new double[length];

            for (int i = 0; i < length; i++)
            {
                beta[i] = rightPart[i] / leftPart[i][i];
                for (int j = 0; j < length; j++)
                {
                    alpha[i][j] = (i != j) ? -leftPart[i][j] / leftPart[i][i] : 0;
                }
            }

            Array.Copy(beta, x, length);

            int iter = 0;
            do
            {
                Array.Copy(x, p, length);

                for (int i = 0; i < length; i++)
                {
                    double[] c = new double[length];
                    for (int j = 0; j < length; j++)
                    {
                        c[i] += alpha[i][j] * p[j];
                    }

                    x[i] = beta[i] + c[i];
                }
                iter++;
            } while (!Converge(ref x, ref p));

            Answer = x;
        }
    }
}
