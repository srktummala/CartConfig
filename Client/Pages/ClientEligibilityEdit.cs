using CartConfig.Client.Services;
using CartConfig.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartConfig.Client.Pages
{
    public partial class ClientEligibilityEdit
    {        
        [Inject]
        public IAssistanceRequestDataService AssistanceRequestDataService { get; set; }
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
        [Parameter]
        public string AssistanceRequestId { get; set; }
        public RulesEligibility RulesEligibility { get; set; } = new RulesEligibility();        
        public FarmBill FarmBill { get; set; } = new FarmBill();
        public Programs Program { get; set; } = new Programs();
        public Contract Contract { get; set; } = new Contract();
        public Jurisdiction Jurisdiction { get; set; } = new Jurisdiction();
        public Status Status { get; set; } = new Status();
        public ProgramComponent ProgramComponent { get; set; } = new ProgramComponent();
        public AssistanceRequest AssistanceRequest { get; set; } = new AssistanceRequest();
        protected string FarmBillId = string.Empty;
        protected string ProgramId = string.Empty;
        protected string ProgramName = string.Empty;
        protected string ProgramComponentId = string.Empty;
        protected string ProgramComponentName = string.Empty;
        protected string ContractId = string.Empty;
        protected string JurisdictionId = string.Empty;
        protected string StatusId = string.Empty;
        protected string RadioValueIsLandInState = string.Empty;
        protected string RadioValueIsTheProducerInterested = string.Empty;
        protected string RadioValueTypeOfClient = string.Empty;
        protected string RadioValueYearsFarming = string.Empty;

        List<string> rdIsLandInState = new List<string> { "Yes", "No" };        
        List<string> rdIsTheProducerInterested = new List<string> { "Maybe A Little Bit", "Not Really", "Depends" };
        List<string> rdTypeOfClient = new List<string> { "Veteran", "Beginner Farmer", "Socially Disadvantaged", "None" };
        List<string> rdYearsFarming = new List<string> { "Less Than Two Years", "2 to 5 yrs", "More Than 5 yrs" };

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

            RulesEligibility = await RulesEligibilityDataService.GetRulesEligibilityDetails(int.Parse(RulesEligibilityId));
            FarmBill = await FarmBillDataService.GetFarmBillById(RulesEligibility.FarmBillId);
            Program = await ProgramDataService.GetProgramById(RulesEligibility.ProgramId);
            ProgramComponent = await ProgramComponentDataService.GetProgramComponentById(RulesEligibility.ProgramComponentId);
            //AssistanceRequest = await AssistanceRequestDataService.GetAssistanceRequestByRulesEligibilityId(int.Parse(RulesEligibilityId));
            
        }

        protected async Task HandleValidSubmit()
        {            
            Saved = false;          

            AssistanceRequest.RulesEligibilityID = int.Parse(RulesEligibilityId);
            AssistanceRequest.IsLandInState = RadioValueIsLandInState;
            AssistanceRequest.IsTheProducerInterested = RadioValueIsTheProducerInterested;
            AssistanceRequest.TypeOfClient = RadioValueTypeOfClient;
            AssistanceRequest.YearsFarming = RadioValueYearsFarming;

            if (AssistanceRequest.AssistanceRequestID == 0)
            {
                var addedAssistanceRequest = await AssistanceRequestDataService.AddAssistanceRequest(AssistanceRequest);
                if (addedAssistanceRequest != null)
                {
                    StatusClass = "alert-success";
                    Message = "New survey items added successfully.";
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
                await AssistanceRequestDataService.UpdateAssistanceRequest(AssistanceRequest);
                StatusClass = "alert-success";
                Message = "Survey Items updated successfully";
                Saved = true;
            }

        }

        void RadioSelectionIsLandInState(ChangeEventArgs args)
        {
            RadioValueIsLandInState = args.Value.ToString();            
        }

        void RadioSelectionIsTheProducerInterested(ChangeEventArgs args)
        {            
            RadioValueIsTheProducerInterested = args.Value.ToString();         
        }

        void RadioSelectionTypeOfClient(ChangeEventArgs args)
        {           
            RadioValueTypeOfClient = args.Value.ToString();         
        }

        void RadioSelectionYearsFarming(ChangeEventArgs args)
        {            
            RadioValueYearsFarming = args.Value.ToString();
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

        protected async Task DeleteAssistanceRequest()
        {
            await AssistanceRequestDataService.DeleteAssistanceRequest(AssistanceRequest.AssistanceRequestID);

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
