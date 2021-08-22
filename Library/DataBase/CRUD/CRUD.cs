using Library.DataBase.ORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.CRUD
{
    // TODO: Реализовать CRUD с использованием ADO и рефлексии

    //       Вывести информацию о самом популярном авторе, наиболее читающем абоненте,
    //       наиболее востребованном жанре.

    //       Сформировать список книг, которые требуют восстановления

    //       При формировании отчётов предусмотреть возможность различных сортировок и
    //       группировок

    //       Для обработки данных в коллекциях использовать LINQ to Objects

    //       Обеспечить невозможность инъекций кода

    //       При реализации DAO использовать синглтон и фабрику (фабричный метод)
    //       при реализации DAO рекомендуется использовать рефлексию
    public static class CRUD<T> where T : class
    {
        public static string GetHeads(string[] headers, string auto)
        {
            string result = string.Empty;
            foreach (var item in headers)
                result += auto + item + ", ";
            return result;
        }
        // TODO: headers - использовать как ToString объекта
        public static void Create(object sender, string[] headers)
        {
            //Type type = sender.GetType();
            //PropertyInfo[] properties = type.GetProperties();


            //string query = $"INSERT INTO [{sender.GetType().Name}] " +
            //    $"({GetHeads(headers, "")}) VALUES ({GetHeads(headers, "@")}";
            //SqlCommand command = new SqlCommand(query, ConnectionSettings.GetConnection());

            //for (int i = 0; i < headers.Length; i++)
            //{
            //    command.Parameters.AddWithValue(headers[i], sender.);
            //}
            //command.Parameters.AddWithValue("Author", this.Author);
            //command.Parameters.AddWithValue("Name", this.Name);
            //command.Parameters.AddWithValue("Genre", this.Genre);

            //command.ExecuteNonQuery();
        }

        public static List<T> Read(Type objType)
        {
            ConnectionSettings.OpenConnection();
            SqlDataReader dataReader = null;
            List<T> list = new List<T>();

            try
            {
                string query = $"SELECT * FROM {objType.Name}";
                SqlCommand command = new SqlCommand(query, ConnectionSettings.GetConnection());

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    object obj = Activator.CreateInstance(objType);
                    obj = Entity.SetObject(obj, dataReader);
                    list.Add((T)obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
            
            return list;

        }

        public static void Update()
        {

        }

        public static void Delete()
        {

        }
    }
}
