using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    public class Books : Entity
    {
        public Books(int id, string author, string name, string genre)
        {
            Id = id;
            Author = author;
            Name = name;
            Genre = genre;
        }

        public Books()
        {
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
