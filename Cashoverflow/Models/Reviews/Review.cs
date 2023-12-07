using System.Text.Json.Serialization;
using Cashoverflow.Models.Companies;

namespace Cashoverflow.Models.Reviews;

public class Review
{
    public Guid Id { get; set; }
    public int Stars { get; set; }
    public string Thoughts { get; set; }

    public Guid CompanyId { get; set; }
    [JsonIgnore]
    public Company Company { get; set; }
}