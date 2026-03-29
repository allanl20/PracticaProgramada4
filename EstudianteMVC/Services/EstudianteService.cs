using System.Text;
using System.Text.Json;
using EstudianteMVC.Models;

namespace EstudianteMVC.Services
{
    public class EstudianteService
    {
        private readonly HttpClient _httpClient;

        public EstudianteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7203/api/estudiantes/");
        }

        public async Task<List<Estudiante>> GetAll()
        {
            var response = await _httpClient.GetAsync("");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Estudiante>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Estudiante> GetById(int id)
        {
            var response = await _httpClient.GetAsync(id.ToString());
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Estudiante>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task Create(Estudiante estudiante)
        {
            var json = JsonSerializer.Serialize(estudiante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("", content);
        }

        public async Task Update(int id, Estudiante estudiante)
        {
            var json = JsonSerializer.Serialize(estudiante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(id.ToString(), content);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync(id.ToString());
        }
    }
}