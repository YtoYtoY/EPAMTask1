using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Algebra.Classes;
using Algebra.SLAE;
using Algebra.Transfer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algebra.Tests
{
    [TestClass]
    public class Transfer_UnitTest
    {
        [TestMethod]
        public void Http_UnitMethod()
        {
            HttpTransfer http = new HttpTransfer();
            http.requestString[0] = "https://raw.githubusercontent.com/YtoYtoY/EpamTasks/master/Algebra/Tests/test1.A";
            http.requestString[1] = "https://raw.githubusercontent.com/YtoYtoY/EpamTasks/master/Algebra/Tests/test1.B";

            var solveMethod = new IterationMethod();
            http.Request(solveMethod);

            var otvet = solveMethod.Answer;

            Assert.IsTrue(true);
        }
    }
}
