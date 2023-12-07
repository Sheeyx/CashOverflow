using Cashoverflow.Models.Locations;
using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker : EFxceptionsContext
{
    private readonly IConfiguration configuration;
    
    public StorageBroker(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.Database.Migrate();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = this.configuration.GetConnectionString(name: "DefaultConnection");
        optionsBuilder.UseSqlite("Data Source=CashOverflow.db");
    }
}