using Cashoverflow.Models.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Review> Reviews { get; set; }
}