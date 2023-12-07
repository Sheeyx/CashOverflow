namespace Cashoverflow.Models.Languages;

public class Language
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Type Type { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    
}