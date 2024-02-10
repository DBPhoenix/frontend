namespace Core.Entities;

public struct Country
{
    public required CountryIdentifiable Identifiable { get; set; }
    public CountryOverview? Overview { get; set; }
    public CountryDetail? Detail { get; set; }
}
