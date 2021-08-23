using Library.Classes;
using Library.DataBase.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DataBase
{
    /// <summary>
    /// This class is responsible for queries to ORM entities using Linq to Object
    /// </summary>
    public static class Queries
    {
        /// <summary>
        /// The request displays information about the most popular author
        /// </summary>
        /// <returns>Author's name</returns>
        public static string GetMostPopularAuthors_Query()
        {
            var exSB = Library.SubscribersBooksList.Cast<SubscriberBooks>();
            var exAB = Library.AuthorBooks.Cast<AuthorBooks>();
            var exAuthors = Library.Authors.Cast<Authors>();

            return (from ab in exAB
                    from sub in exSB
                    from author in exAuthors

                    where sub.BookId == ab.BookId
                    group ab by ab.BookId into grp

                    select new
                    {
                        Author =
                        (from item in grp
                         from author in exAuthors

                         where item.AuthorId == author.Id
                         orderby author.Name
                         select author.Name).First()
                    }).First().ToString();

        }

        /// <summary>
        /// The request displays information about the most read subscriber
        /// </summary>
        /// <returns>Subscriber's name</returns>
        public static string GetMostReadingSub_Query()
        {
            var exSB = Library.SubscribersBooksList.Cast<SubscriberBooks>();
            var exSubs = Library.SubscribersList.Cast<Subscribers>();

            return (from sb in exSB
                       from sub in exSubs

                       where sb.SubskriberId == sub.Id
                       orderby sub.Id
                       select sub.FullName
                       ).First();

        }

        /// <summary>
        /// The request displays information about the most popular genre
        /// </summary>
        /// <returns>Genre name</returns>
        public static string GetMostPopularGenre_Query()
        {
            var exGenre = Library.Genre.Cast<Genre>();
            var exSB = Library.SubscribersBooksList.Cast<SubscriberBooks>();
            var exBooks = Library.BooksList.Cast<Books>();

            return (from sb in exSB
                    from book in exBooks

                    where sb.BookId == book.Id
                    group book by book.GenreId into grp

                    select new
                    {
                        Genre =
                        (from item in grp
                         from gnr in exGenre

                         where item.GenreId == gnr.Id
                         select gnr.Name
                        ).First()
                    }).First().ToString();
        }


        /// <summary>
        /// The request generates a list of books requiring restoration
        /// </summary>
        /// <returns>Broken books list</returns>
        public static List<Books> GetBooksInPoorCondition_Query()
        {
            var exBooks = Library.BooksList.Cast<Books>();
            var exSB = Library.SubscribersBooksList.Cast<SubscriberBooks>();

            return (from book in exBooks
                    from sb in exSB

                    where sb.StateId <= Constants.BookQualityAssessment &&
                    sb.BookId == book.Id

                    select book).ToList();
        }

        /// <summary>
        /// The request displays information about how many times each
        /// book was taken, for each subscriber for the specified period
        /// </summary>
        /// <param name="first">Beginning of period</param>
        /// <param name="last">End of period</param>
        /// <returns>Returning a dictionary for output to the report</returns>
        public static IDictionary<string, IEnumerable<Books>> GetBooksInformByTime_Query(DateTime first, DateTime last)
        {
            var exBooks = Library.BooksList.Cast<Books>();
            var exSB = Library.SubscribersBooksList.Cast<SubscriberBooks>();
            var exSubs = Library.SubscribersList.Cast<Subscribers>();

            return (from book in exBooks
                    from sb in exSB
                    from sub in exSubs

                    where sb.DateOfTake >= first &&
                    sb.DateOfTake <= last &&
                    sb.SubskriberId == sub.Id


                    group sub by sub.FullName into grp
                    select new
                    {
                        name = grp.Key,
                        list = (from b in exBooks
                                from sb in exSB
                                from sub in exSubs

                                where grp.Key == sub.FullName &&
                                sub.Id == sb.SubskriberId &&
                                sb.BookId == b.Id

                                select b)
                    }).ToDictionary((x => x.name), (x => x.list));

        }

        /// <summary>
        /// Query displays information about the collected books, grouped by genre.
        /// </summary>
        /// <returns>Returning a dictionary for output to the report</returns>
        public static IDictionary<string, IEnumerable<Books>> GetTakenBooksByGenre_Query()
        {

            var exBooks = Library.BooksList.Cast<Books>();
            var exSB = Library.SubscribersBooksList.Cast<SubscriberBooks>();
            var exGenre = Library.Genre.Cast<Genre>();

            return (from book in exBooks
                    from sb in exSB
                    from gnr in exGenre

                    where sb.BookId == book.Id &&
                    book.GenreId == gnr.Id

                    group gnr by gnr.Name into grp
                    select new
                    {
                        name = grp.Key,
                        count = grp.Count(),
                        list = (from b in exBooks
                                from gnr in exGenre

                                where gnr.Name == grp.Key &&
                                gnr.Id == b.GenreId

                                select b)
                    }).ToDictionary((x => x.name + ", " + x.count.ToString()), (x => x.list));
        }
    }
}
