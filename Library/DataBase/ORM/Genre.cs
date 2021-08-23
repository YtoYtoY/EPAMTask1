using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - Genre
    /// </summary>
    public class Genre : Entity
    {
        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Genre() { }

        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   Id == genre.Id &&
                   Name == genre.Name;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return "\t" + "{ " +
                "Id: " + Id +
                ", Name:" + Name +
                "} ";
        }
    }
}
