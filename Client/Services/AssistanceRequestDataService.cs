using CartConfig.Client.Services;
using CartConfig.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RulesEngineUI.Services
{
    public class AssistanceRequestDataService : IAssistanceRequestDataService
    {
        private readonly HttpClient _httpClient;

        public AssistanceRequestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AssistanceRequest>> GetAllAssistanceRequest()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<AssistanceRequest>>
                     (await _httpClient.GetStreamAsync($"api/AssistanceRequest"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<AssistanceRequest> GetAssistanceRequestById(int AssistanceRequestId)
        {
            return await JsonSerializer.DeserializeAsync<AssistanceRequest>
                (await _httpClient.GetStreamAsync($"api/AssistanceRequest/{AssistanceRequestId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<AssistanceRequest> GetAssistanceRequestDetails(int AssistanceRequestId)
        {
            return await JsonSerializer.DeserializeAsync<AssistanceRequest>
                (await _httpClient.GetStreamAsync($"api/AssistanceRequest/{AssistanceRequestId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<AssistanceRequest> AddAssistanceRequest(AssistanceRequest AssistanceRequest)
        {
            var configJson =
                new StringContent(JsonSerializer.Serialize(AssistanceRequest), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/AssistanceRequest", configJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<AssistanceRequest>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateAssistanceRequest(AssistanceRequest AssistanceRequest)
        {
            var configJson =
                new StringContent(JsonSerializer.Serialize(AssistanceRequest), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/AssistanceRequest", configJson);

        }

        public async Task DeleteAssistanceRequest(int AssistanceRequestID)
        {
            await _httpClient.DeleteAsync($"api/AssistanceRequest/{AssistanceRequestID}");
        }

        public async Task<AssistanceRequest> GetAssistanceRequestByRulesEligibilityId(int RulesEligibilityId)
        {
            return await JsonSerializer.DeserializeAsync<AssistanceRequest>
                (await _httpClient.GetStreamAsync($"api/AssistanceRequest/{RulesEligibilityId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
