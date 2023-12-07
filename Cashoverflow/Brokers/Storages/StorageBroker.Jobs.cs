using Cashoverflow.Models.Jobs;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Job> Jobs { get; set; }
}