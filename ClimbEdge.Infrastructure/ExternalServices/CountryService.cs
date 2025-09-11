using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClimbEdge.Application.Interfaces.Ports;
using ClimbEdge.Domain.ExternalEntities;

namespace ClimbEdge.Infrastructure.ExternalServices
{
    public class CountryService : ICountryService
    {
        // documentation: https://restcountries.com/
        private const string BaseUrl = "https://restcountries.com/v3.1";
        private readonly HttpClient _httpClient;
        private const string fields = "fields=cca2,cca3,altSpellings,idd,continents,currencies,languages,name,timezones,postalCodes";
        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<Country> GetCountryInfoAsync(string countryCode)
        {
            const string endpoint = "/alpha";
            var res = await _httpClient.GetAsync($"{endpoint}/{countryCode}?{fields}");
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching country info for code {countryCode}: {res.ReasonPhrase}");
            }
            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Country>(json)!;
        }

        public async Task<IEnumerable<Country>> GetCountryInfoAsync()
        {
            const string endpoint = "/all";
            var res = await _httpClient.GetAsync($"{endpoint}?{fields}");
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching countries info: {res.ReasonPhrase}");
            }
            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Country>>(json)!;
        }

        public async Task<IEnumerable<Country>> GetCountryInfoAsync(IEnumerable<string> countryCodes)
        {
            const string endpoint = "/alpha";
            var res = await _httpClient.GetAsync($"{endpoint}?codes={string.Join('&',countryCodes)}&{fields}");
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching countries info: {res.ReasonPhrase}");
            }
            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Country>>(json)!;
        }
    }
}
