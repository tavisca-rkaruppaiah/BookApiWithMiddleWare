using BookApi.Entities;
using BookApi.Responses;
using BookApi.Services;
using System;
using Xunit;

namespace BookApi.Tests
{
    public class UnitTestForWebApi
    {
        BookService service = new BookService();
        Response response;
        Book book;
        [Fact]
        public void IsIdNegativeNumber()
        {
            response = service.Get(-1);
            Assert.Equal("Invalid Id, Id should be a positive number", response.error.message);

        }

        [Fact]
        public void CreateBook()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor",
                category = "SciFi",
                price = 200,
                author = "JKRowling"
            };

            response = service.Post(book);
            Assert.Equal(book.id, response.book.id);
        }

        [Fact]
        public void IsNameInvalid()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor1",
                category = "SciFi",
                price = 200,
                author = "JKRowling"
            };
            response = service.Post(book);
            Assert.Equal("Name should be letters only", response.error.message);

        }

        [Fact]
        public void IsCategoryInvalid()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor",
                category = "SciFi2",
                price = 200,
                author = "JKRowling"
            };
            response = service.Post(book);
            Assert.Equal("Category should be letters only", response.error.message);

        }

        [Fact]
        public void IsAuthorInvalid()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor",
                category = "SciFi",
                price = 200,
                author = "JKRowling12"
            };
            response = service.Post(book);
            Assert.Equal("AuthorName should be letters only", response.error.message);

        }
    }
}
