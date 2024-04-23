using System.Runtime.Serialization;

namespace AngularWebApi.ApplicationCore.Exceptions;

public class UserAlreadyExistException : Exception
{
    public UserAlreadyExistException()
    {
    }

    public UserAlreadyExistException(string? message) : base(message)
    {
    }

    public UserAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UserAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
