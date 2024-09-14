namespace SalonManager.Auth.CrossCutting.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message)
            : base(message)
        {
        }
    }
}
