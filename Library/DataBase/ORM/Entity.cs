using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    public class Entity
    {
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
