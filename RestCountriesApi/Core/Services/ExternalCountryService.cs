using System.Net.Http.Json;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

internal class ExternalCountryService(HttpClient client) : ICountryService
{
    public Country[] All()
    {
        const string requestUri = "https://restcountries.com/v3.1/all?fields=cca3,flags,name,population,region,capital"; 
        CountryAllDto[] result = client.GetFromJsonAsync<CountryAllDto[]>(requestUri).Result!;
        return result.Select(data => new Country
        {
            Identifiable = new CountryIdentifiable
            {
                CCA3 = data.CCA3,
                Name = data.Name.Common
            },
            Overview = new CountryOverview
            {
                FlagUri = data.Flags.Png,
                FlagAlt = data.Flags.Alt,
                Population = data.Population,
                Region = data.Region,
                Capital = data.Capital.FirstOrDefault()
            }
        }).ToArray();
    }

    public Country Get(string cca3)
    {
        string requestUri = $"https://restcountries.com/v3.1/alpha/{cca3}?fields=cca3,flags,name,population,region,capital,nativeName,tld,currencies,languages,subregion,borders"; 
        CountryAlphaDto result = client.GetFromJsonAsync<CountryAlphaDto>(requestUri).Result;
        return new Country
        {
            Identifiable = new CountryIdentifiable
            {
                CCA3 = result.CCA3,
                Name = result.Name.Common
            },
            Overview = new CountryOverview
            {
                FlagUri = result.Flags.Png,
                FlagAlt = result.Flags.Alt ?? "",
                Population = result.Population,
                Region = result.Region,
                Capital = result.Capital.FirstOrDefault()
            },
            Detail = new CountryDetail
            {
                NativeName = result.Name.NativeName.Values.FirstOrDefault().Common,
                TopLevelDomain = result.TLD.FirstOrDefault(),
                Currencies = result.Currencies.Values.Select(currency => currency.Name).ToArray(),
                Languages = result.Languages.Values.ToArray(),
                SubRegion = result.Subregion,
                BorderCountries = GetNames(result.Borders.ToArray())
            }
        };
    }

    private CountryIdentifiable[] GetNames(string[] codes)
    {
        if (codes.Length == 0)
            return [];

        string requestUri = $"https://restcountries.com/v3.1/alpha?codes={string.Join(",", codes)}&fields=ccn3,name"; 
        CountryNameDto[] result = client.GetFromJsonAsync<CountryNameDto[]>(requestUri).Result!;
        return result.Select(data => new CountryIdentifiable
        {
            CCA3 = data.CCA3,
            Name = data.Name.Common
        }).ToArray();
    }
    
    private struct CountryAllDto
    {
        public string CCA3 { get; set; }
        
        public struct FlagDto
        {
            public string Png { get; set; }
            public string Alt { get; set; }
        }

        public struct NameDto
        {
            public string Common { get; set; }
        }

        public FlagDto Flags { get; set; }
        public NameDto Name { get; set; }
        public int Population { get; set; }
        public string[] Capital { get; set; }
        public string Region { get; set; }
    }

    private struct CountryAlphaDto
    {
        public struct FlagDto
        {
            public string Png { get; set; }
            public string? Alt { get; set; }
        }

        public struct NameDto
        {
            public string Common { get; set; }
            public Dictionary<string, NameDto> NativeName { get; set; }
        }
        
        public struct CurrencyDto
        {
            public string Name { get; set; }
        }
        
        public string CCA3 { get; set; }
        public FlagDto Flags { get; set; }
        public NameDto Name { get; set; }
        public int Population { get; set; }
        public string[] Capital { get; set; }
        public string Region { get; set; }
        
        public string[] TLD { get; set; }
        public Dictionary<string, CurrencyDto> Currencies { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public string? Subregion { get; set; }
        public string[] Borders { get; set; }
    }

    private struct CountryNameDto
    {
        public struct NameDto
        {
            public string Common { get; set; }
        }

        public string CCA3 { get; set; }
        public NameDto Name { get; set; }
    }
}