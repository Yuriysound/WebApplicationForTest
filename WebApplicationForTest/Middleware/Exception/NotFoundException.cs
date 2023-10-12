using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationForTest.Middleware.Exception
{
    public class NotFoundException : SystemException
    {
        public NotFoundException(string message)
            : base(message) { }
    }
}
