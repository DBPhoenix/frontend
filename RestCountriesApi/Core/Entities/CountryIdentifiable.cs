namespace Core.Entities;

public struct CountryIdentifiable
{
    public required string CCA3 { get; set; }
    public required string Name { get; init; }
}