using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    public class SubscriberBooks : Entity
    {
        public SubscriberBooks(int semiId, int subskriberId, int bookId, DateTime dateOfTake, bool isTaken, int stateId)
        {
            SemiId = semiId;
            SubskriberId = subskriberId;
            BookId = bookId;
            DateOfTake = dateOfTake;
            IsTaken = isTaken;
            StateId = stateId;
        }

        public SubscriberBooks()
        {
        }

        public int SemiId { get; set; }
        public int SubskriberId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfTake { get; set; }
        public bool IsTaken { get; set; }
        public int StateId { get; set; }



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
