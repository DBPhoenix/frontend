using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterCoreDependencies(this IServiceCollection services) =>
        services
            .AddSingleton<HttpClient>(_ => new HttpClient())
            .AddScoped<ICountryService, ExternalCountryService>();
}