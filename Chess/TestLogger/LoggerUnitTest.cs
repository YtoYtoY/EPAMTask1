using System;
using Chess.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProgram.TestLogger
{
    [TestClass]
    public class LoggerUnitTest
    {
        [TestMethod]
        public void DataWriter_TestMethod()
        {
            DataRegister logger = new DataRegister();
            Information.AddLog("Test1");
            Information.AddLog("Test2");
            Information.AddLog("Test3");
            Information.AddLog("Test4");
            Information.AddLog("Test5");
            Information.AddLog("Test6");
            logger.WriteLogData();

        }
    }
}
