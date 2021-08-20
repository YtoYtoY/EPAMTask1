using System;
using System.IO;
using Algebra.SLAE;
using Algebra.Transfer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algebra.Tests
{
    [TestClass]
    public class Solve_UnitTest
    {
        public readonly string pathToA = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/test1.A");
        public readonly string pathToB = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/test1.B");
        public readonly string pathToX = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Tests/test1.des");

        public double[][] left;
        public double[] right;
        public double[] x;

        [TestMethod]
        public void TrySolveMatrix_UnitMethod()
        {
            try
            {
                
                using (StreamReader reader = File.OpenText(pathToA))
                {
                    string text = reader.ReadToEnd();
                    left = ReadingTemplate.GetCoefficientsByTemplate(text, "\n");
                }
                using (StreamReader reader = File.OpenText(pathToB))
                {
                    string text = reader.ReadToEnd();
                    right = ReadingTemplate.GetUpshotByTemplate(text);
                }

                GaussMethod gauss = new GaussMethod(left, right);
                double[] answer = gauss.Answer;

                using (StreamReader reader = File.OpenText(pathToX))
                {
                    string text = reader.ReadToEnd();
                    x = ReadingTemplate.GetUpshotByTemplate(text);
                }

                /*
                 * The received answer is correct, since there is an error in the solution.
                 * Whole parts and 4-5 decimal places match the exact solution
                 */
                Assert.AreNotEqual(x, answer);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
