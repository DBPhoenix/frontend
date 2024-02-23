using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazor.Components.Pages;

public partial class Home
{
    [Inject]
    public required ICountryService Country { private get; init; }

    private Country[] Countries { get; set; } = Array.Empty<Country>();
    private string[] Regions { get; set; } = Array.Empty<string>();

    protected override Task OnInitializedAsync()
    {
        Countries = Country.All();
        Regions = Enum.GetNames<Region>();
        return base.OnInitializedAsync();
    }
}
