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
    public class RulesEligibilityDataService : IRulesEligibilityDataService
    {
        private readonly HttpClient _httpClient;

        public RulesEligibilityDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RulesEligibility>> GetAllRulesEligibility()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<RulesEligibility>>
                     (await _httpClient.GetStreamAsync($"api/ruleseligibility"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<RulesEligibility> GetRulesEligibilityById(int rulesEligibilityId)
        {
            return await JsonSerializer.DeserializeAsync<RulesEligibility>
                (await _httpClient.GetStreamAsync($"api/ruleseligibility/{rulesEligibilityId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<RulesEligibility> GetRulesEligibilityDetails(int rulesEligibilityId)
        {
            return await JsonSerializer.DeserializeAsync<RulesEligibility>
                (await _httpClient.GetStreamAsync($"api/ruleseligibility/{rulesEligibilityId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<RulesEligibility> AddRulesEligibility(RulesEligibility rulesEligibility)
        {
            var configJson =
                new StringContent(JsonSerializer.Serialize(rulesEligibility), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/ruleseligibility", configJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<RulesEligibility>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateRulesEligibility(RulesEligibility rulesEligibility)
        {
            var configJson =
                new StringContent(JsonSerializer.Serialize(rulesEligibility), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/ruleseligibility", configJson);

        }

        public async Task DeleteRulesEligibility(int rulesEligibilityID)
        {
            await _httpClient.DeleteAsync($"api/ruleseligibility/{rulesEligibilityID}");
        }
    }
}
