using System.Text.RegularExpressions;

namespace ChurchSchool.Domain.Structs
{
    public struct Phone
    {
        private const string REGEX_BRAZILIAN_NUMBER = @"[\(?0-9\)?]{2,4}\s{1}?9?[0-9]{4}-?[0-9]{4}";
        public string AreaCode { get; set; }
        public string Number { get; set; }

        public bool ValidateBrazilianNumber()
        {
            return ValidateBrazilianNumber(phoneNumber: ToString());
        }

        public bool ValidateBrazilianNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, REGEX_BRAZILIAN_NUMBER);
        }

        public override string ToString()
        {
            return $"({AreaCode}) {Number}";
        }
    }
}