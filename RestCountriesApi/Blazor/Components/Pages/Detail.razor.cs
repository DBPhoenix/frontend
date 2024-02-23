using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazor.Components.Pages;

public partial class Detail
{
    [Inject]
    public required ICountryService Service { private get; init; }
    [SupplyParameterFromQuery]
    public required string Cca3 { private get; init; }

    private Country? Country { get; set; }

    protected override Task OnInitializedAsync()
    {
        Country = Service.Get(Cca3);
        return base.OnInitializedAsync();
    }
}