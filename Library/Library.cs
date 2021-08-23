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
        /// <summary>
        /// Author-Books table information
        /// </summary>
        public static IEnumerable<object> AuthorBooks { get; set; }

        /// <summary>
        /// Authors table information
        /// </summary>
        public static IEnumerable<object> Authors { get; set; }

        /// <summary>
        /// Genre table information
        /// </summary>
        public static IEnumerable<object> Genre { get; set; }

        /// <summary>
        /// States table information
        /// </summary>
        public static IEnumerable<object> StatesList { get; set; }

        /// <summary>
        /// Subskribers table information
        /// </summary>
        public static IEnumerable<object> SubscribersList { get; set; }

        /// <summary>
        /// Books table information
        /// </summary>
        public static IEnumerable<object> BooksList { get; set; }

        /// <summary>
        /// Subskribers-Books table information
        /// </summary>
        public static IEnumerable<object> SubscribersBooksList { get; set; }

        /// <summary>
        /// Method for defining all lists of entities
        /// </summary>
        public static void GetAll()
        {
            int propIndex = 0;
            Type baseType = typeof(Entity);
            IEnumerable<Type> entityTypes = Assembly.GetAssembly(baseType).GetTypes().Where(type => type.IsSubclassOf(baseType));

            var libraryLists = typeof(Library).GetProperties();
            foreach (var item in entityTypes)
            {
                Library library = new Library();

                var tmp = CRUD<Entity>.Read(item);

                libraryLists[propIndex].SetValue(library, tmp);
                propIndex++;
            }
        }

        
    }
}
