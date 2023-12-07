namespace Cashoverflow.Models.Companies;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}