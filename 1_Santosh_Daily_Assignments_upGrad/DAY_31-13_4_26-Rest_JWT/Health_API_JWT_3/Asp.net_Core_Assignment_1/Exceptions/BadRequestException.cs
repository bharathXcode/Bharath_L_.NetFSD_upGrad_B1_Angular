namespace Asp.net_Core_Assignment_1.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string message):base(message) { }
    }
}
