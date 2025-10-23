using System.Net.Http.Json;

namespace CA1_Nicolai_deGroot.Services
{
    public class CountryService
    {
        private readonly HttpClient _http;

        public CountryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            try
            {
                var url = "https://restcountries.com/v3.1/all?fields=name,capital,flags,population,region";
                var countries = await _http.GetFromJsonAsync<List<Country>>(url);
                return countries ?? new List<Country>();
            }
            catch
            {
                return new List<Country>();
            }
        }

        public async Task<Country?> GetCountryAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            try
            {
                var url = $"https://restcountries.com/v3.1/name/{name}?fullText=true";
                var countries = await _http.GetFromJsonAsync<List<Country>>(url);
                return countries?.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }

    public class Country
    {
        public Name Name { get; set; } = new Name();
        public List<string>? Capital { get; set; }
        public long Population { get; set; }
        public string Region { get; set; } = "";
        public Flags? Flags { get; set; }
    }

    public class Name
    {
        public string Common { get; set; } = "";
        public string Official { get; set; } = "";
    }

    public class Flags
    {
        public string Png { get; set; } = "";
        public string Svg { get; set; } = "";
    }
}
