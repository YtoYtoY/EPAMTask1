using Library.DataBase;
using Library.DataBase.CRUD;
using Library.DataBase.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library
    {

        public static IEnumerable<Entity> StatesList { get; set; }
        public static IEnumerable<Entity> SubscribersList { get; set; }
        public static IEnumerable<Entity> BooksList { get; set; } 
        public static IEnumerable<Entity> SBList { get; set; }


        public static void GetAll()
        {
            ConnectionSettings.OpenConnection();

            int propIndex = 0;
            Type baseType = typeof(Entity);
            IEnumerable<Type> entityTypes = Assembly.GetAssembly(baseType).GetTypes().Where(type => type.IsSubclassOf(baseType));

            var libraryLists = typeof(Library).GetProperties();
            foreach (var item in entityTypes)
            {
                Library library = new Library();
                List<Entity> tmp = CRUD<Entity>.Read(item);
                libraryLists[propIndex].SetValue(library, tmp);
                propIndex++;
            }

            ConnectionSettings.CloseConnection();
        }

        
    }
}
