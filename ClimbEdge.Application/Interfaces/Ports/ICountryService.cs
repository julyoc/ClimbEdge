using ClimbEdge.Domain.ExternalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.Interfaces.Ports
{
    public interface ICountryService
    {
        Task<Country> GetCountryInfoAsync(string countryCode);
        Task<IEnumerable<Country>> GetCountryInfoAsync(IEnumerable<string> countryCodes);
        Task<IEnumerable<Country>> GetCountryInfoAsync();
    }
}
