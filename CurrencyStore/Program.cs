using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using CurrencyStore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<StoredCurrencyDb>(options => options.UseInMemoryDatabase("currencies"));
var connectionString = builder.Configuration.GetConnectionString("Currencies") ?? "Data Source=Currencies.db";
builder.Services.AddSqlite<StoredCurrencyDb>(connectionString);
builder.Services.AddDbContext<StoredCurrencyDb>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CurrencyStore API",
        Description = "Exercising for SEB",
        Version = "v1"
    });
});


var app = builder.Build();

#region dbRoutes

app.MapGet("/currencies", async (StoredCurrencyDb db) => await db.Currencies.ToListAsync());
app.MapPost("/currency", async (StoredCurrencyDb db, StoredCurrency currency) =>
{
    await db.Currencies.AddAsync(currency);
    await db.SaveChangesAsync();
    return Results.Created($"/currency/{currency.Id}", currency);
});
app.MapGet("/currency/{id}", async (StoredCurrencyDb db, int id) => await db.Currencies.FindAsync(id));

app.MapPut("/currency/{id}", async (StoredCurrencyDb db, StoredCurrency updateCurrency, int id) =>
{
    var currency = await db.Currencies.FindAsync(id);
    if (currency is null) return Results.NotFound();
    currency.Name = updateCurrency.Name;
    currency.FullName = updateCurrency.FullName;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/currency/{id}", async (StoredCurrencyDb db, int id) =>
{
    var currency = await db.Currencies.FindAsync(id);
    if (currency is null) return Results.NotFound();
    db.Currencies.Remove(currency);

    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion dbRoutes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrencyStore API V1");
});

app.MapGet("/", () => "Hello World!");

app.Run();
