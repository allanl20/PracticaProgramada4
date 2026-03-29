using System.Text.Json;
using EstudianteMVC.Models;

namespace EstudianteMVC.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
          
            _httpClient = httpClient;

            
            _httpClient.BaseAddress = new Uri("https://localhost:7203/");
        }

        public async Task<List<WeatherForecast>> GetAll()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            if (!response.IsSuccessStatusCode)
            {
                return new List<WeatherForecast>(); 
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<WeatherForecast>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}