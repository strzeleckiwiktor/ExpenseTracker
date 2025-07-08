using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Exceptions
{
    public class ForeignKeyConstraintViolationException : Exception
    {
        public ForeignKeyConstraintViolationException() { }
        public ForeignKeyConstraintViolationException(string message) : base(message) { }
        public ForeignKeyConstraintViolationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
