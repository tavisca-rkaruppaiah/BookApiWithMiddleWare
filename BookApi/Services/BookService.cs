using BookApi.Entities;
using BookApi.Errors;
using BookApi.Interfaces;
using BookApi.Logging;
using BookApi.Models;
using BookApi.Responses;
using BookApi.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class BookService
    {
        BookLibrary libray = new BookLibrary();
        BookValidator validate = new BookValidator();
        List<Error> errors = new List<Error>();
        ILogger logger = new FileLogger();
        
        public Response Delete(int id)
        {
            if (Validate.IsIdPositiveNumber(id))
            {
                if (libray.Remove(id))
                {
                    logger.Log("Deleted : " + "Successfully" + " " + DateTime.Now);
                    return new Response(new Book(), null);
                }
                else
                {
                    logger.Log("Error Occured while Deleting a Book : IdNotFound " + DateTime.Now);
                    return new Response(null, new Error("Id", "IdNotFound"));
                }
            }
            else
            {
                logger.Log("Error Occured while Deleting a Book : InValid Id Should Be Positive " + DateTime.Now);
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }

        public List<Book> Get()
        {
            return libray.Get();
        }

        public Response Get(int id)
        {
            if (Validate.IsIdPositiveNumber(id))
            {
                if (libray.Get(id) != null)
                {
                    logger.Log("Fetched : Successfully " + DateTime.Now);
                    return new Response(libray.Get(id), null);
                }
                else
                {
                    logger.Log("Error Occured while Geting Book : IdNotFound " + DateTime.Now);
                    return new Response(null, new Error("Id", "IdNotFound"));
                }

            }
            else
            {
                logger.Log("Error Occured while Getting Book : InValid Id Should Be Positive " + DateTime.Now);
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }

        public Response Post(Book book)
        {
            var result = validate.Validate(book);
            if (result.IsValid)
            {
                libray.Add(book);
                logger.Log("Created : " + book.ToString() + " Added Successfully" + " " + DateTime.Now);
                return new Response(book, null);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errors.Add(new Error(error.PropertyName, error.ErrorMessage));
                }
                logger.Log("Error Occured while Creating Book : " + errors[0].message + " " + DateTime.Now);
                return new Response(null, errors[0]);

            }
        }

        public Response Put(int id, Book book)
        {
            var result = validate.Validate(book);
            if (Validate.IsIdPositiveNumber(id))
            {
                if (result.IsValid)
                {
                    if (libray.Update(id, book))
                    {
                        logger.Log("Updated :" + book.ToString() + " Updated Successfully");
                        return new Response(book, null);
                    }
                    else
                    {
                        logger.Log("Error in Updating Book : IdNotFound " + DateTime.Now);
                        return new Response(null, new Error("Id", "IdNotFound"));
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        errors.Add(new Error(error.PropertyName, error.ErrorMessage));
                    }
                    logger.Log("Error Occured while Updating Book : " + errors[0].message + " " + DateTime.Now);
                    return new Response(null, errors[0]);
                }
            }
            else
            {
                logger.Log("Error in Updating Book : InValid Id Should Be Positive " + DateTime.Now);
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }
    }
}
