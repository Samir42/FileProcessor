using System;

namespace FileProcessor.Application.Exceptions
{
    public class FieldRequiredException : ApplicationException
    {
        public FieldRequiredException(string field)
            : base($"{field} value has to be provided")
        {

        }
    }
}
