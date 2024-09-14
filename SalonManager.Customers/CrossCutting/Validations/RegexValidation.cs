using System.Text.RegularExpressions;

namespace SalonManager.Customers.CrossCutting.Validations
{
    public static partial class RegexValidation
    {
        public static bool ValidaCpf(string cpf) => CpfRegex().IsMatch(cpf);
        public static bool ValidaCNPJ(string cnpj) => CNPJRegex().IsMatch(cnpj);

        [GeneratedRegex("[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}")]
        private static partial Regex CpfRegex();

        [GeneratedRegex("[0-9]{2}\\.?[0-9]{3}\\.?[0-9]{3}\\/?[0-9]{4}\\-?[0-9]{2}")]
        private static partial Regex CNPJRegex();
    }
}
