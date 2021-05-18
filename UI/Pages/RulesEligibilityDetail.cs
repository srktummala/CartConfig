using CartConfig.Shared;
using Microsoft.AspNetCore.Components;
using RulesEngine.UI.Services;
using System.Threading.Tasks;


namespace RulesEngine.UI.Pages
{
    public partial class RulesEligibilityDetail
    {
        [Parameter]
        public string RulesEligibilityId { get; set; }     
        public RulesEligibility RulesEligibility { get; set; } = new RulesEligibility();
        public FarmBill FarmBill { get; set; } = new FarmBill();
        public Programs Programs { get; set; } = new Programs();
        public ProgramComponent ProgramComponent { get; set; } = new ProgramComponent();
        public Contract Contract { get; set; } = new Contract();
        public Jurisdiction Jurisdiction { get; set; } = new Jurisdiction();
        [Inject]
        public IRulesEligibilityDataService RulesEligibilityDataService { get; set; }
        [Inject]
        public IFarmBillDataService FarmBillDataService { get; set; }
        [Inject]
        public IProgramDataService ProgramDataService { get; set; }
        [Inject]
        public IProgramComponentDataService ProgramComponentDataService { get; set; }
        [Inject]
        public IContractDataService ContractDataService { get; set; }
        [Inject]
        public IJurisdictionDataService JurisdictionDataService { get; set; }
        protected async override Task OnInitializedAsync()
        {            
            RulesEligibility = await RulesEligibilityDataService.GetRulesEligibilityDetails(int.Parse(RulesEligibilityId));            
            FarmBill = await FarmBillDataService.GetFarmBillById(RulesEligibility.FarmBillId);
            Programs = await ProgramDataService.GetProgramById(RulesEligibility.ProgramId);
            ProgramComponent = await ProgramComponentDataService.GetProgramComponentById(RulesEligibility.ProgramComponentId);
            Contract = await ContractDataService.GetContractById(RulesEligibility.ContractId);
            Jurisdiction = await JurisdictionDataService.GetJurisdictionById(RulesEligibility.JurisdictionId);
        }
    }
}
