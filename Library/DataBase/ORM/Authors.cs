using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - Authors
    /// </summary>
    public class Authors : Entity
    {
        
        public Authors(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Authors() { }

        public int Id { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return "\t" + "{ " +
                "Id: " + Id +
                ", Name: " + Name +
                "} ";
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Authors authors &&
                   Id == authors.Id &&
                   Name == authors.Name;
        }
    }
}
