using System.Runtime.Serialization;

[Serializable]
public class InvalidNameException : Exception
{
    public InvalidNameException()
    {
    }

    public InvalidNameException(string? message) : base(message)
    {
    }

    public InvalidNameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidNameException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}