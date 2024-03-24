using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
namespace CurrencyStore
{
    public class StoredCurrency
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public string? FullName { get; set; }   
        public decimal? Rate { get; set;}

        
    }

    public class StoredCurrencyDb : DbContext
    {
        public StoredCurrencyDb(DbContextOptions options) : base(options) { }
        public DbSet<StoredCurrency> Currencies { get; set; } = null!;
    }
}
