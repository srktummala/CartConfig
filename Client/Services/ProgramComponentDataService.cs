using CartConfig.Client.Services;
using CartConfig.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartConfig.Client
{
    public class ProgramComponentDataService : IProgramComponentDataService
    {
        private readonly HttpClient _httpClient;

        public ProgramComponentDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProgramComponent>> GetAllProgramComponents()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProgramComponent>>
                     (await _httpClient.GetStreamAsync($"api/programcomponent"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ProgramComponent> GetProgramComponentById(int programComponentId)
        {
            return await JsonSerializer.DeserializeAsync<ProgramComponent>
                (await _httpClient.GetStreamAsync($"api/programcomponent/{programComponentId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }        
        
    }
}
