using System;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DAL.Exceptions
{
    public class InvalidReviewException : Exception
    {
        public InvalidReviewException(Review review)
        {

        }
    }
}
