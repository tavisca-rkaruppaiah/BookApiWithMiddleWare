using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Validator
{
    public class Validate
    {
        public static bool IsIdPositiveNumber(int id)
        {
            return id > 0;
        }
    }
}
