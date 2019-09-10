using BookApi.Entities;
using BookApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Interfaces
{
    public interface IServices
    {
        Response Post(Book book);
        List<Book> Get();
        Response Get(int id);
        Response Put(int id, Book book);
        Response Delete(int id);
    }
}
