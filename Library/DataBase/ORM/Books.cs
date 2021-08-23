using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - Books
    /// </summary>
    public class Books : Entity
    {
        public Books(int id, string name, int genreId)
        {
            Id = id;
            Name = name;
            GenreId = genreId;
        }

        public Books()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }


        public override string ToString()
        {
            return "\t" + "{ " +
                "Id: " + this.Id +
                ", Name: " + this.Name +
                ", Ganre id: " + GenreId +
                " }";
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Name);
            hash.Add(this.GenreId);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Books books &&
                   Id == books.Id &&
                   Name == books.Name &&
                   GenreId == books.GenreId;
        }
    }
}
