using System;
using Chess.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProgram.TestLogger
{
    [TestClass]
    public class LoggerUnitTest
    {
        [TestMethod]
        public void DataWriter_UnitTest()
        {
            DataRegister logger = new DataRegister();
            var information = new Information();
            information.AddLog("Test1");
            information.AddLog("Test2");
            information.AddLog("Test3");
            information.AddLog("Test4");
            information.AddLog("Test5");
            information.AddLog("Test6");
            logger.WriteLogData(information.LogText);
            //Assert.AreEqual(0, 0);
        }
    }
}
