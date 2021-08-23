using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - States
    /// </summary>
    public class States : Entity
    {
        public States(int id, string stateName)
        {
            Id = id;
            StateName = stateName;
        }

        public States() { }
        

        public int Id { get; set; }
        public string StateName { get; set; }

        public override string ToString()
        {
            return "\t" + "{ " +
                "Id: " + Id +
                ", State name: " + StateName +
                "} ";
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(StateName);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is States states &&
                   Id == states.Id &&
                   StateName == states.StateName;
        }
    }
}
