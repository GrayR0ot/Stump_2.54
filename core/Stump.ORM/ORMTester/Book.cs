using System;
using System.Collections.Generic;
using System.Data;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace ORMTester
{
    public enum BookType
    {
        Romance,
        Polar,
    }

    public class BookRelator
    {
        public static string FetchQuery = "SELECT * FROM books LEFT JOIN authors ON books.AuthorId = authors.Id";

        private Dictionary<int, Author> m_authors = new Dictionary<int,Author>();
        public Book Map(Book book, Author author)
        {
            if (author.Id != 0)
            {
                Author outAutor;
                if (!m_authors.TryGetValue(author.Id, out outAutor))
                {
                    outAutor = author;
                    m_authors.Add(outAutor.Id, outAutor);
                }

                book.Author = outAutor;
                outAutor.Books.Add(book);
            }

            return book;
        }
    }

    [TableName("books")]
    public class Book : IAutoGeneratedRecord
    {
        public Book()
        {
            
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public BookType Type
        {
            get;
            set;
        }

        [Stump.ORM.Ignore]
        public Author Author
        {
            get;
            set;
        }

        public int? AuthorId
        {
            get { return Author != null ? (int?)Author.Id : null; }
            set {  }
        }

        public DateTime PublicationDate
        {
            get;
            set;
        }
    }
}