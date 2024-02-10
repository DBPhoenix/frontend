using Core.Entities;

namespace Core.Interfaces;

public interface ICountryService
{
    public Country[] All();
    public Country Get(string cca3);
}