using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    public class States : Entity
    {
        public States(int id, string stateName)
        {
            Id = id;
            StateName = stateName;
        }

        public States()
        {
        }

        public int Id { get; set; }
        public string StateName { get; set; }

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
