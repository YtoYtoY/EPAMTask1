using System;
using System.Data.SqlClient;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// The base Entity class for simplified retrieval of data from the database using reflection
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Method for setting data to properties of objects inherited by this class
        /// </summary>
        /// <param name="obj">Current object</param>
        /// <param name="reader">Information obtained from the database</param>
        /// <returns>Filled object</returns>
        public static Entity SetObject(Object obj, SqlDataReader reader)
        {

            int readerIndex = 0;
            foreach (var prop in obj.GetType().GetProperties())
            {
                var typeConvert = prop.PropertyType;
                prop.SetValue(obj, reader[readerIndex]);
                readerIndex++;
            }
            return (Entity)obj;
        }

    }
}
