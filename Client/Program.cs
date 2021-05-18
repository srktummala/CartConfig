using CartConfig.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RulesEngineUI.Services;
using System;
using System.Threading.Tasks;

namespace CartConfig.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
           /*
            builder.Services.AddHttpClient<IFarmBillDataService, FarmBillDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IProgramDataService, ProgramDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IProgramComponentDataService, ProgramComponentDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IConfigItemsDataService, ConfigItemsDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IRulesEligibilityDataService, RulesEligibilityDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IContractDataService, ContractDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IJurisdictionDataService, JurisdictionDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IStatusDataService, StatusDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
            builder.Services.AddHttpClient<IAssistanceRequestDataService, AssistanceRequestDataService>(client => client.BaseAddress = new Uri("http://localhost:53526/"));
           */

            builder.Services.AddHttpClient<IFarmBillDataService, FarmBillDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));
            builder.Services.AddHttpClient<IProgramDataService, ProgramDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));
            builder.Services.AddHttpClient<IProgramComponentDataService, ProgramComponentDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));            
            builder.Services.AddHttpClient<IRulesEligibilityDataService, RulesEligibilityDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));
            builder.Services.AddHttpClient<IContractDataService, ContractDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));
            builder.Services.AddHttpClient<IJurisdictionDataService, JurisdictionDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));
            builder.Services.AddHttpClient<IStatusDataService, StatusDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));
            builder.Services.AddHttpClient<IAssistanceRequestDataService, AssistanceRequestDataService>(client => client.BaseAddress = new Uri("http://localhost:33333/"));

            await builder.Build().RunAsync();
        }
    }
}
