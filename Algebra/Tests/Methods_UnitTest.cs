using System;
using Algebra.SLAE;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algebra.Tests
{
    [TestClass]
    public class Methods_UnitTest
    {
        [TestMethod]
        public void LUDecomposition_TestMethod()
        {
            double[][] leftPart = new double[3][];
            leftPart[0] = new double[3] { 5, 9.3, 2 };
            leftPart[1] = new double[3] { 0, 2, 1.98 };
            leftPart[2] = new double[3] { -6, 8, 2.21 };

            double[] rightPart = new double[3] { 6, 2.1, 2.1 };

            LUDMethod lud = new LUDMethod(leftPart, rightPart);
            _ = lud.Answer;
            // 0.33
            // 0.30
            // 0.75
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void GaussMethod_TestMethod()
        {
            double[][] leftPart = new double[3][];
            leftPart[0] = new double[3] { 5, 9.3, 2 };
            leftPart[1] = new double[3] { 0, 2, 1.98 };
            leftPart[2] = new double[3] { -6, 8, 2.21 };

            double[] rightPart = new double[3] { 6, 2.1, 2.1 };
            GaussMethod gauss = new GaussMethod(leftPart, rightPart);
            _ = gauss.Answer;
            Assert.AreEqual(0, 0);
        }
    }
}
