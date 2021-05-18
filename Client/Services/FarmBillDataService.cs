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
    public class FarmBillDataService : IFarmBillDataService
    {
        private readonly HttpClient _httpClient;

        public FarmBillDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FarmBill>> GetAllFarmBills()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<FarmBill>>
                     (await _httpClient.GetStreamAsync($"api/farmbill"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<FarmBill> GetFarmBillById(int farmBillId)
        {
            return await JsonSerializer.DeserializeAsync<FarmBill>
                (await _httpClient.GetStreamAsync($"api/farmbill/{farmBillId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }        
        
    }
}
