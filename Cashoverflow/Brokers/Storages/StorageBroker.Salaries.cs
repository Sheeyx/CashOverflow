using Cashoverflow.Models.Salaries;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Salary> Salaries { get; set; }
}