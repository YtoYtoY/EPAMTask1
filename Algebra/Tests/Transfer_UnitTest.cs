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
        string[] test1 = new string[]
        {
            "https://raw.githubusercontent.com/YtoYtoY/EpamTasks/master/Algebra/Tests/test1.A",
            "https://raw.githubusercontent.com/YtoYtoY/EpamTasks/master/Algebra/Tests/test1.B"
        };

        string[] test2 = new string[]
        {
            "https://raw.githubusercontent.com/YtoYtoY/EpamTasks/master/Algebra/Tests/mytest4.A",
            "https://raw.githubusercontent.com/YtoYtoY/EpamTasks/master/Algebra/Tests/mytest4.B"
        };

        [TestMethod]
        public void Http_UnitMethod()
        {
            HttpTransfer http = new HttpTransfer();

            http.requestString = test1;

            var solveMethod = new GaussMethod();
            http.Request(solveMethod);

            var result = solveMethod.Answer;

            Assert.IsTrue(true);
        }
    }
}
