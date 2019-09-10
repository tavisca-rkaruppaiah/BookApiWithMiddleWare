using BookApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class BookLibrary
    {
        private static List<Book> books = new List<Book>();
        public List<Book> Get()
        {
            return books;
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public Book Get(int id)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].id == id)
                    return books[i];
            }
            return null;
        }

        public bool Remove(int id)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].id == id)
                {
                    books.RemoveAt(i);
                    return true;
                }

            }
            return false;
        }

        public bool Update(int id, Book book)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].id == id)
                {
                    books[i] = book;
                    return true;
                }

            }
            return false;
        }
    }
}
