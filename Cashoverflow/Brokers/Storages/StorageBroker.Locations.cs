using Cashoverflow.Models.Locations;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Location> Locations { get; set; }
}