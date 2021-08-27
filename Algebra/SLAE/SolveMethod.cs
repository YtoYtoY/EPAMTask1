using Algebra.Classes;
using Algebra.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.SLAE
{
    /// <summary>
    /// Abstract class describing the method for solving SLAE
    /// </summary>
    public abstract class SolveMethod
    {
        /// <summary>
        /// Array of resulting coefficients
        /// </summary>
        public double[] Answer { get; protected set; }

        /// <summary>
        /// "Left" coefficients of the equation (A)
        /// </summary>
        public double[][] LeftPart { get; set; }

        /// <summary>
        /// "Right" coefficients of the equation (B)
        /// </summary>
        public double[] RightPart { get; set; }

        /// <summary>
        /// The number of elements in the array of "right" coefficients
        /// </summary>
        public int N { get; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="leftPart">coefficients of the equation (A)</param>
        /// <param name="rightPart">coefficients of the equation (B)</param>
        protected SolveMethod(double[][] leftPart, double[] rightPart)
        {
            LeftPart = leftPart;
            RightPart = rightPart;

            N = RightPart.GetLength(0);
            Answer = new double[N];
        }

        protected SolveMethod() { }

        /// <summary>
        /// An abstract method for solving an equation
        /// </summary>
        /// <param name="leftPart">coefficients of the equation (A)</param>
        /// <param name="rightPart">coefficients of the equation (B)</param>
        public abstract void TrySolve(double[][] leftPart, IReadOnlyList<double> rightPart);

        public override string ToString()
        {
            string result = string.Empty;
            for(int i = 0; i < Answer.Length; i++)
                result += Answer[i] + '\t';
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is SolveMethod method &&
                Answer == method.Answer &&
                LeftPart == method.LeftPart &&
                RightPart == method.RightPart;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Answer);
            hash.Add(LeftPart);
            hash.Add(RightPart);
            return hash.ToHashCode();
        }
    }
}
