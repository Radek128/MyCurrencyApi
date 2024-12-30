namespace MyCurrencyApi.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; init; }
        public Currency Currency { get; init; }

        public Money()
        {
        }
        public Money(decimal amount, Currency currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            }
            Amount = amount;
            Currency = currency;
        }
    }
}
