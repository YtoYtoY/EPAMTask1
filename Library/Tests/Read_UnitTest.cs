using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class Read_UnitTest
    {
        [TestMethod]
        public void Reader_UnitMethod()
        {
            Library.GetAll();
            Library.GetAll();

            var statesList = Library.StatesList;
            var booksList = Library.BooksList;

            Assert.IsTrue(true);
        }
    }
}
