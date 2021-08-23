using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - Subskribers-Books
    /// </summary>
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
            return "{ " +
                "Id: " + SemiId +
                ", Subskriber id: " + SubskriberId +
                ", Book id: " + BookId +
                ", Date of take: " + DateOfTake +
                ", Is taken: " + IsTaken +
                ", State id: " + StateId +
                "} ";
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(SemiId);
            hash.Add(SubskriberId);
            hash.Add(BookId);
            hash.Add(DateOfTake);
            hash.Add(IsTaken);
            hash.Add(StateId);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is SubscriberBooks books &&
                   SemiId == books.SemiId &&
                   SubskriberId == books.SubskriberId &&
                   BookId == books.BookId &&
                   DateOfTake == books.DateOfTake &&
                   IsTaken == books.IsTaken &&
                   StateId == books.StateId;
        }
    }
}
