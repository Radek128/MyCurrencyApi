using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurrencyApi.Application.Abstracts;
using MyCurrencyApi.Application.Models;

namespace MyCurrencyApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRatesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CurrencyRatesDto>> Get(
            [FromServices] ICurrencyRateRepository currencyRateRepository,
            [FromQuery] string currencyCode, 
            [FromQuery] string dateTime)
        {
            return Ok(await currencyRateRepository.GetCurrencyRatesAsync(currencyCode, DateOnly.Parse(dateTime)));
        }
    }
}
