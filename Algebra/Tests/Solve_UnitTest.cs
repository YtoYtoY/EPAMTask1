using System;
using System.IO;
using System.Linq;
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

                var gauss = new GaussMethod();
                gauss.TrySolve(left, right);
                double[] answer = gauss.Answer;

                using (StreamReader reader = File.OpenText(pathToX))
                {
                    string text = reader.ReadToEnd();
                    x = ReadingTemplate.GetUpshotByTemplate(text);
                }

                CollectionAssert.AreEquivalent(
                    x.Select(i => (int)i).ToArray(),
                    answer.Select(i => (int)i).ToArray()
                    );
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
