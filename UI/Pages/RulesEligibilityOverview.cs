using CartConfig.Shared;
using Microsoft.AspNetCore.Components;
using RulesEngine.UI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RulesEngine.UI.Pages
{
    public partial class RulesEligibilityOverview
    {
        public IEnumerable<RulesEligibility> RulesEligibilities { get; set; }
        public FarmBill FarmBill { get; set; } = new FarmBill();        

        [Inject]
        public IRulesEligibilityDataService RulesEligibilityDataService { get; set; }
        [Inject]
        public IFarmBillDataService FarmBillDataService { get; set; }      

        protected async override Task OnInitializedAsync()
        {
            RulesEligibilities = (await RulesEligibilityDataService.GetAllRulesEligibility()).ToList();
           
        }
    }
}
