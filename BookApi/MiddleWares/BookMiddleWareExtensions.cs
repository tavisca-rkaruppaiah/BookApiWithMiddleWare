using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.MiddleWares
{
    public static class BookMiddleWareExtensions
    {
        public static IApplicationBuilder UseBookMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BookMiddleWare>();
        }
    }
}
