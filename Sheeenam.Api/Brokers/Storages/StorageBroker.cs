//===============================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use Comfort and Peace
//===============================================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sheeenam.Api.Models.Foundations.Guests;

namespace Sheeenam.Api.Brokers.Storages
{
    public partial  class StorageBroker:EFxceptionsContext,IStorageBroker
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

        public override void Dispose() {}
    }
}
