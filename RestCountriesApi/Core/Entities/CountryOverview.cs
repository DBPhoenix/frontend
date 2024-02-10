namespace Core.Entities;

public struct CountryOverview
{
    public required string FlagUri { get; init; }
    public required string FlagAlt { get; init; }
    public required int Population { get; init; }
    public required string Region { get; init; }
    public required string? Capital { get; init; }
}
