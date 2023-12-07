using Cashoverflow.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Company> Companies { get; set; }
}