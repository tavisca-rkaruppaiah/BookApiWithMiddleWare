using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Entities
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public string author { get; set; }
    }
}
