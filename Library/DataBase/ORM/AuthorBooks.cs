using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.ORM
{
    /// <summary>
    /// Table - Author-Books
    /// </summary>
    public class AuthorBooks : Entity
    {
        public AuthorBooks(int semiId, int bookId, int authorId)
        {
            SemiId = semiId;
            BookId = bookId;
            AuthorId = authorId;
        }

        public AuthorBooks() { }


        public int SemiId { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AuthorBooks books &&
                   SemiId == books.SemiId &&
                   BookId == books.BookId &&
                   AuthorId == books.AuthorId;
        }

        public override string ToString()
        {
            return "\t" + "{ " +
                "Semi id: " + SemiId +
                ", Book id: " + BookId +
                ", Author id: " + AuthorId +
                "} ";
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(SemiId);
            hash.Add(BookId);
            hash.Add(AuthorId);
            return hash.ToHashCode();
        }
    }
}
