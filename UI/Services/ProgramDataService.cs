using CartConfig.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public class ProgramDataService : IProgramDataService
    {
        private readonly HttpClient _httpClient;

        public ProgramDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Programs>> GetAllPrograms()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Programs>>
                     (await _httpClient.GetStreamAsync($"api/program"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Programs> GetProgramById(int programId)
        {
            return await JsonSerializer.DeserializeAsync<Programs>
                (await _httpClient.GetStreamAsync($"api/program/{programId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
