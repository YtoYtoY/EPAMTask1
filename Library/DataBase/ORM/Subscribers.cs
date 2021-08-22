using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    public class Subscribers : Entity
    {
        public Subscribers()
        {
        }

        public Subscribers(int id, string fullName, string sex, DateTime dateOfBirth)
        {
            Id = id;
            FullName = fullName;
            Sex = sex;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
