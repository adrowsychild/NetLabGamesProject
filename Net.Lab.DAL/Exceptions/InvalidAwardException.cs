using System;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.DAL.Exceptions
{
    public class InvalidAwardException : Exception
    {
        public InvalidAwardException(Award award)
        {

        }
    }
}
