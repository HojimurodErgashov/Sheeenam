using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sheeenam.Api.Models.Foundations.Guests;

namespace Sheeenam.Api.Brokers.Storages
{
    public  class StorageBroker:EFxceptionsContext
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Guest> Guests { get; set; }
        public override void Dispose() {}
    }
}
