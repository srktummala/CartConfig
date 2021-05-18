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
    public class ContractDataService : IContractDataService
    {
        private readonly HttpClient _httpClient;

        public ContractDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Contract>> GetAllContracts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Contract>>
                     (await _httpClient.GetStreamAsync($"api/contract"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Contract> GetContractById(int contractId)
        {
            return await JsonSerializer.DeserializeAsync<Contract>
                (await _httpClient.GetStreamAsync($"api/contract/{contractId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
