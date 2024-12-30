using Microsoft.EntityFrameworkCore;
using MyCurrencyApi.Application.Abstracts;
using MyCurrencyApi.Infrastructure.DAL;
using MyCurrencyApi.Infrastructure.DAL.Repositories;
using MyCurrencyApi.Infrastructure.Exceptions;
using MyCurrencyApi.Infrastructure.HostedServices;
using MyCurrencyApi.Infrastructure.HttpClients;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient<INbpClient, NbpHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://api.nbp.pl");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddSingleton<ExceptionMiddleware>();
builder.Services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();
builder.Services.AddHostedService<SeedCurrencyRatesBackgroundService>();
builder.Services.AddHostedService<SaveCurrentCurrencyRatesBackgroundService>();
builder.Services.AddDbContext<CurrencyRateDbContext>(x => x.UseNpgsql("Host=localhost;Database=MyCurrency;Username=postgres;Password="));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CurrencyRateDbContext>();
    await dbContext.Database.MigrateAsync();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
