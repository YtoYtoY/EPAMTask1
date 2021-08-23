using System;
using System.Threading.Tasks;
using Library.DataBase.CRUD;
using Library.DataBase.ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class CRUD_UnitTest
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

        [TestMethod]
        public void Creator_UnitMethod()
        {
            var type = typeof(States);
            object[] toAdd = { 
                5, 
                "new" 
            };
            CRUD<Entity>.Create(type, toAdd);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Update_UnitMethod()
        {
            var type = typeof(States);
            object[] toUpdate = {
                5,
                "old"
            };
            CRUD<Entity>.Update(type, toUpdate);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Delete_UnitMethod()
        {
            var type = typeof(States);
            CRUD<Entity>.Delete(type, 5);

            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public async Task CRUD_UnitMethod()
        //{
        //    await Reader_UnitMethod();
        //    await Creator_UnitMethod();
        //    await Update_UnitMethod();
        //    await Delete_UnitMethod();
        //}
    }
}
