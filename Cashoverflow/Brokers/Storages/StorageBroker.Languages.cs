using Cashoverflow.Models.Languages;
using Microsoft.EntityFrameworkCore;

namespace Cashoverflow.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Language> Languages { get; set; }
}