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
    /// Delegate for event
    /// </summary>
    /// <param name="sender">Current object</param>
    /// <param name="e">EventArgs object</param>
    public delegate void EventDelegate(object sender, EventArgs e);

    /// <summary>
    /// Abstract class describing the method for solving SLAE
    /// </summary>
    public abstract class SolveMethod
    {
        /// <summary>
        /// Event to check and solve the equation
        /// </summary>
        public event EventDelegate GoToSolve = null;

        /// <summary>
        /// Array of resulting coefficients
        /// </summary>
        public double[] Answer { get; protected set; }

        /// <summary>
        /// "Left" coefficients of the equation (A)
        /// </summary>
        protected double[][] LeftPart { get; set; }

        /// <summary>
        /// "Right" coefficients of the equation (B)
        /// </summary>
        protected double[] RightPart { get; set; }

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

        /// <summary>
        /// The method raises an event
        /// </summary>
        /// <param name="left">Matrix</param>
        /// <param name="right">Array</param>
        public void InvokeEvent(double[][] left, double[] right)
        {

            if (left != null && right != null)
            {
                if(LinearCheck(left, right))
                {
                    GoToSolve?.Invoke(this, new EventArgs());
                    TrySolve(left, right);
                    return;
                }
            }
            throw new Exception(Exceptions.NonLinearException);
        }

        /// <summary>
        /// Checking for the correctness of the equation
        /// </summary>
        /// <param name="leftPart">coefficients of the equation (A)</param>
        /// <param name="rightPart">coefficients of the equation (B)</param>
        /// <returns>Return true if the lengths of the arrays are the same</returns>
        public bool LinearCheck(double[][] leftPart, double[] rightPart)
        {
            return (leftPart[0].Length == rightPart.Length);
        }

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
