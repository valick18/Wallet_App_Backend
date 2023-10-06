using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WalletAppBackend.Data.Models;

namespace WalletAppBackend.Data
{
    public class DataBaseContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DataBaseContext(IConfiguration configuration) { 
            this.configuration = configuration;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Users> users { get; set; }
        public DbSet<SeasonalPoints> seasonalpoints { get; set; }
        public DbSet<Transactions> transactions { get; set; }

    }
}
