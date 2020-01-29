using System;

namespace Defiance.Bolton.Domain.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string integrationExceptionMessage) : base(integrationExceptionMessage)
        {

        }
    }
}
