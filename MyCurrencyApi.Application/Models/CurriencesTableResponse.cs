namespace MyCurrencyApi.Application.Models
{
    public record CurriencesTableResponse
    {
        public string Table { get; init; } 
        public string No { get; init; } 
        public DateOnly EffectiveDate { get; init; } 
        public List<Rate> Rates { get; init; } 

    }

    public record Rate
    {
        public string Currency { get; init; } 
        public string Code { get; init; } 
        public decimal Bid { get; init; }
        public decimal Ask { get; init; }
    }
}
