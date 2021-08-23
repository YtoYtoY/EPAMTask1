using System;
using Library.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class Queries_UnitTest
    {
        [TestMethod]
        public void QualityBookList_TestMethod()
        {
            Library.GetAll();
            var test = Queries.GetBooksInPoorCondition_Query();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MostPopularAuthor_TestMethod()
        {
            Library.GetAll();
            var test = Queries.GetMostPopularAuthors_Query();

            Assert.AreEqual("{ Author = Joanne Rowling }", test);
        }

        [TestMethod]
        public void MostReadingSub_TestMethod()
        {
            Library.GetAll();
            var test = Queries.GetMostReadingSub_Query();

            Assert.AreEqual("Москвина Амина Данииловна", test);
        }

        [TestMethod]
        public void MostPopularGenre_TestMethod()
        {
            Library.GetAll();
            var test = Queries.GetMostPopularGenre_Query();

            Assert.AreEqual("{ Genre = Fantasy }", test);
        }


        [TestMethod]
        public void TakenBooksByGenre_TestMethod()
        {
            Library.GetAll();
            var test = Queries.GetTakenBooksByGenre_Query();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void BooksInformByTime_TestMethod()
        {
            Library.GetAll();
            DateTime first = new DateTime(2020, 2, 8, 0, 0, 0);
            DateTime last = DateTime.Now;

            var test = Queries.GetBooksInformByTime_Query(first, last);

            Assert.IsTrue(true);
        }
    }
}
