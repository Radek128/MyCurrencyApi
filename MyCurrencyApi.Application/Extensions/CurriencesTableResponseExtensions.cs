using MyCurrencyApi.Application.Models;
using MyCurrencyApi.Domain.Entities;
using MyCurrencyApi.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurrencyApi.Application.Extensions
{
    public static class CurriencesTableResponseExtensions
    {
        public static List<CurrencyRate> ToCurrencyRatesList(this CurriencesTableResponse curriencesTable)
        {
            var askRate = curriencesTable.Rates.Select(x => new AskRate(Guid.NewGuid(), new (x.Ask, Currency.FromCode(x.Code)), curriencesTable.EffectiveDate));
            var bidRate = curriencesTable.Rates.Select(x => new BidRate(Guid.NewGuid(), new(x.Bid, Currency.FromCode(x.Code)), curriencesTable.EffectiveDate));
            return [..askRate, ..bidRate];
        } 
    }
}
