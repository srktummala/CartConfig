using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IAssistanceRequestDataService
    {

        Task<IEnumerable<AssistanceRequest>> GetAllAssistanceRequest();
        Task<AssistanceRequest> GetAssistanceRequestDetails(int assistanceRequestId);
        Task<AssistanceRequest> GetAssistanceRequestById(int assistanceRequestId);
        Task<AssistanceRequest> AddAssistanceRequest(AssistanceRequest AssistanceRequest);
        Task UpdateAssistanceRequest(AssistanceRequest AssistanceRequest);
        Task DeleteAssistanceRequest(int assistanceRequestID);
        Task<AssistanceRequest> GetAssistanceRequestByRulesEligibilityId(int RulesEligibilityId);
    }
}
