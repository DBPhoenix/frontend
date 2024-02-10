namespace Core.Entities;

public struct CountryDetail
{
    public required string NativeName { get; set; }
    public required string? TopLevelDomain { get; set; }
    public required string[] Currencies { get; set; }
    public required string[] Languages { get; set; }
    public required string? SubRegion { get; set; }
    public required CountryIdentifiable[] BorderCountries { get; set; }
}
