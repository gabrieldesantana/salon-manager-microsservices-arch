namespace SalonManager.Business.CrossCutting.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message)
            : base(message)
        {
        }
    }
}
