using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace Common.Domain.ValueObjects
{
    public class PhoneNumber:ValueObject
    {
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length != 11)
            {
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است!");
            }
            Value = value;
        }

        public string Value { get; private set; }
    }
}