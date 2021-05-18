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
    public class StatusDataService : IStatusDataService
    {
        private readonly HttpClient _httpClient;

        public StatusDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Status>>
                     (await _httpClient.GetStreamAsync($"api/status"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Status> GetStatusById(int statusId)
        {
            return await JsonSerializer.DeserializeAsync<Status>
                (await _httpClient.GetStreamAsync($"api/status/{statusId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }        
        
    }
}
