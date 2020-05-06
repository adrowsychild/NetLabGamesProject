using System;
using Net.Lab.DataContracts.Games;

namespace Net.Lab.DAL.Exceptions
{
    public class InvalidGameException : Exception
    {
        public InvalidGameException(Game invalidGame)
        {
        }
    }
}
