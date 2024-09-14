namespace SalonManager.Auth.CrossCutting.Exceptions
{
    public class InvalidRequestDataException : ApplicationException
    {
        public InvalidRequestDataException(IDictionary<string, IEnumerable<string>> messages)
            : base("Dados invalidos") => Erros = messages.Select(m => $"{m.Key} : {string.Join(", ", m.Value)}");

        public IEnumerable<string> Erros { get; }
    }
}
