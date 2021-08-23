using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - Subskriber
    /// </summary>
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
            return obj is Subscribers subscribers &&
                   Id == subscribers.Id &&
                   FullName == subscribers.FullName &&
                   Sex == subscribers.Sex &&
                   DateOfBirth == subscribers.DateOfBirth;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(FullName);
            hash.Add(Sex);
            hash.Add(DateOfBirth);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return "{ " +
                "Id: " + Id +
                ", Name: " + FullName +
                ", Sex: " + Sex +
                ", Date of birth: " + DateOfBirth +
                "} ";
        }

    }
}
