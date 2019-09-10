using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Errors
{
    public class Error
    {
        public string name { get; }
        public string message { get; }

        public Error(string name, string message)
        {
            this.name = name;
            this.message = message;
        }
    }
}
