using System.Net.Http.Json;

namespace CA1_Nicolai_deGroot.Services
{
    public class WikipediaService
    {
        private readonly HttpClient _http;

        public WikipediaService(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("BlazorApp/1.0");
        }

        public async Task<string?> GetCountryExtractAsync(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                return null;

            try
            {
                var url = $"https://en.wikipedia.org/api/rest_v1/page/summary/{Uri.EscapeDataString(countryName)}";
                var summary = await _http.GetFromJsonAsync<WikipediaSummary>(url);
                return summary?.Extract;
            }
            catch
            {
                return null;
            }
        }
    }

    public class WikipediaSummary
    {
        public string Title { get; set; } = "";
        public string Extract { get; set; } = "";
    }
}
