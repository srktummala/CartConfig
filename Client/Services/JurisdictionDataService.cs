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
    public class JurisdictionDataService : IJurisdictionDataService
    {
        private readonly HttpClient _httpClient;

        public JurisdictionDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Jurisdiction>> GetAllJurisdictions()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Jurisdiction>>
                     (await _httpClient.GetStreamAsync($"api/jurisdiction"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Jurisdiction> GetJurisdictionById(int jurisdictionId)
        {
            return await JsonSerializer.DeserializeAsync<Jurisdiction>
                (await _httpClient.GetStreamAsync($"api/jurisdiction/{jurisdictionId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
     
    }
}
