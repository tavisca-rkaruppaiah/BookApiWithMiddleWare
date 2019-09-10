using BookApi.Interfaces;
using BookApi.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.MiddleWares
{
    public class BookMiddleWare
    {
        private RequestDelegate _next;
        private ILogger logger = new FileLogger();
        public BookMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var method = context.Request.Method;
            if(method == "GET")
            {
                logger.Log(method+" Geting the details at "+ DateTime.Now);
            }
            else if(method == "POST")
            {
                logger.Log(method + " Trying to create .. " + DateTime.Now);
            }
            else if(method == "PUT")
            {
                logger.Log(method + " Trying to Update .. " + DateTime.Now);
            }
            else if(method == "DELETE")
            {
                logger.Log(method + " Trying to Delete .. " + DateTime.Now);
            }
            
            await _next(context);
            logger.Log("Operations Done and Redirect Successfully");
        }
    }
}
