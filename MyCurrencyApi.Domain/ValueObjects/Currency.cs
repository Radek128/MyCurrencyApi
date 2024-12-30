namespace MyCurrencyApi.Domain.ValueObjects
{
    public record Currency
    {
        public string Code { get; }
        public string Name { get; }

        private Currency() { }
        protected Currency(string code, string name)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static Currency FromCode(string code)
        {
            if (Currencies.TryGetValue(code.ToUpper(), out var currency))
                return currency();

            throw new ArgumentException($"Currency with code '{code}' is not supported.", nameof(code));
        }

        private static readonly Dictionary<string, Func<Currency>> Currencies = new()
        {
            { "PLN",() => new Zloty()},
            { "USD",() => new Usd() },
            { "EUR",() => new Eur() },
            { "AUD",() => new Aud() },
            { "CAD",() => new Cad() },
            { "HUF",() => new Huf() },
            { "CHF",() => new Chf() },
            { "GBP",() => new Gbp() },
            { "JPY",() => new Jpy() },
            { "CZK",() => new Czk() },
            { "DKK",() => new Dkk() },
            { "NOK",() => new Nok() },
            { "SEK",() => new Sek() },
            { "XDR",() => new Xdr() }
        };

        public sealed record Zloty : Currency
        {
            public Zloty() : base("PLN", "złoty") { }
        }

        public sealed record Usd : Currency
        {
            public Usd() : base("USD", "dolar amerykański") { }
        }

        public sealed record Eur : Currency
        {
            public Eur() : base("EUR", "euro") { }
        }

        public sealed record Aud : Currency
        {
            public Aud() : base("AUD", "dolar australijski") { }
        }

        public sealed record Cad : Currency
        {
            public Cad() : base("CAD", "dolar kanadyjski") { }
        }

        public sealed record Huf : Currency
        {
            public Huf() : base("HUF", "forint (Węgry)") { }
        }

        public sealed record Chf : Currency
        {
            public Chf() : base("CHF", "frank szwajcarski") { }
        }

        public sealed record Gbp : Currency
        {
            public Gbp() : base("GBP", "funt szterling") { }
        }

        public sealed record Jpy : Currency
        {
            public Jpy() : base("JPY", "jen (Japonia)") { }
        }

        public sealed record Czk : Currency
        {
            public Czk() : base("CZK", "korona czeska") { }
        }

        public sealed record Dkk : Currency
        {
            public Dkk() : base("DKK", "korona duńska") { }
        }

        public sealed record Nok : Currency
        {
            public Nok() : base("NOK", "korona norweska") { }
        }

        public sealed record Sek : Currency
        {
            public Sek() : base("SEK", "korona szwedzka") { }
        }

        public sealed record Xdr : Currency
        {
            public Xdr() : base("XDR", "SDR (MFW)") { }
        }

        public override int GetHashCode() => Code.GetHashCode();
        public override string ToString() => Code;
    }

}
