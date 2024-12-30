using MyCurrencyApi.Domain.Exceptions;

namespace MyCurrencyApi.Domain.ValueObjects
{
    public sealed record RateId
    {
        public Guid Value { get; }

        public RateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(RateId value) => value.Value;

        public static implicit operator RateId(Guid value) => new(value);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
