using CartConfig.Shared;
using Microsoft.AspNetCore.Components;
using RulesEngine.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RulesEngine.UI.Pages
{
    public partial class RulesEligibilityEdit
    {        
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
        [Inject]
        public IStatusDataService StatusDataService { get; set; }        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string RulesEligibilityId { get; set; }
        public RulesEligibility RulesEligibility { get; set; } = new RulesEligibility();
        public FarmBill FarmBill { get; set; } = new FarmBill();
        public Programs Program { get; set; } = new Programs();
        public Contract Contract { get; set; } = new Contract();
        public Jurisdiction Jurisdiction { get; set; } = new Jurisdiction();
        public Status Status { get; set; } = new Status();
        public ProgramComponent ProgramComponent { get; set; } = new ProgramComponent();
        protected string FarmBillId = string.Empty;
        protected string ProgramId = string.Empty;
        protected string ProgramComponentId = string.Empty;
        protected string ContractId = string.Empty;
        protected string JurisdictionId = string.Empty;
        protected string StatusId = string.Empty;
        //protected bool IsEnrollmentType = false;
        //protected bool IsDuration = false;
        //protected bool IsEasementType = false;
        //protected bool IsPaymentRateSource = false;
        //protected bool IsPracticeSchedule = false;
        //protected bool IsCARTAssessmentRequired = false;
        //protected bool IsCARTRankingRequired = false;
        //protected bool IsApplicationRequired = false;
        //protected string ProgramRuleId = string.Empty;
        //protected bool IsClientEligible = false;

        public List<FarmBill> FarmBills { get; set; } = new List<FarmBill>();
        public List<Programs> Programs { get; set; } = new List<Programs>();
        public List<ProgramComponent> ProgramComponents { get; set; } = new List<ProgramComponent>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public List<Jurisdiction> Jurisdictions { get; set; } = new List<Jurisdiction>();
        public List<Status> Statuses { get; set; } = new List<Status>();

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            FarmBills = (await FarmBillDataService.GetAllFarmBills()).ToList();
            Programs =  (await ProgramDataService.GetAllPrograms()).ToList();
            ProgramComponents = (await ProgramComponentDataService.GetAllProgramComponents()).ToList();
            Contracts = (await ContractDataService.GetAllContracts()).ToList();
            Jurisdictions = (await JurisdictionDataService.GetAllJurisdictions()).ToList();
            Statuses = (await StatusDataService.GetAllStatuses()).ToList();
            int.TryParse(RulesEligibilityId, out var rulesEligibilityId);
            if(rulesEligibilityId == 0)
            {
                //add some defaults
                RulesEligibility = new RulesEligibility { FarmBillId = 1, ProgramId = 1, ProgramComponentId = 1, ContractId=1,JurisdictionId=1,StatusID=1, IsEnrollmentType = true, IsDuration = true, IsEasementType = true, IsPaymentRateSource = true, IsPracticeSchedule = true, IsCARTAssessmentRequired = true, IsCARTRankingRequired = true, IsApplicationRequired = true };
            }
            else
            {
                RulesEligibility = await RulesEligibilityDataService.GetRulesEligibilityDetails(int.Parse(RulesEligibilityId));
            }
            FarmBillId = RulesEligibility.FarmBillId.ToString();
            ProgramId = RulesEligibility.ProgramId.ToString();
            ProgramComponentId = RulesEligibility.ProgramComponentId.ToString();
            ContractId = RulesEligibility.ContractId.ToString();
            JurisdictionId = RulesEligibility.JurisdictionId.ToString();
            StatusId = RulesEligibility.StatusID.ToString();
            

        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;            
            RulesEligibility.FarmBillId = int.Parse(FarmBillId);
            RulesEligibility.ProgramId = int.Parse(ProgramId);
            RulesEligibility.ProgramComponentId = int.Parse(ProgramComponentId);
            RulesEligibility.ContractId = int.Parse(ContractId);
            RulesEligibility.JurisdictionId = int.Parse(JurisdictionId);
            RulesEligibility.StatusID = int.Parse(StatusId);
            RulesEligibility.ProgramRuleId = 1;

            if(RulesEligibility.RulesEligibilityID == 0)
            {
                var addedRulesEligibility = await RulesEligibilityDataService.AddRulesEligibility(RulesEligibility);
                if(addedRulesEligibility != null)
                {
                    StatusClass = "alert-success";
                    Message = "New Rules Engine config item added successfully.";
                    Saved = true;                 
                }
                else 
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new rules eligibility. Please try again.";
                    Saved = false;
                }

               
            }
            else 
            {
                await RulesEligibilityDataService.UpdateRulesEligibility(RulesEligibility);
                StatusClass = "alert-success";
                Message = "Rules Engine Config Items updated successfully";
                Saved = true;            
            }          

        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteRulesEligibility()
        {
            await RulesEligibilityDataService.DeleteRulesEligibility(RulesEligibility.RulesEligibilityID);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/ruleseligibilityoverview");
        }
    }
}
