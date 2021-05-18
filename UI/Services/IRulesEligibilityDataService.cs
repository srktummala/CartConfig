using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IRulesEligibilityDataService
    {

        Task<IEnumerable<RulesEligibility>> GetAllRulesEligibility();
        Task<RulesEligibility> GetRulesEligibilityDetails(int RulesEligibilityId);
        Task<RulesEligibility> GetRulesEligibilityById(int RulesEligibilityId);
        Task<RulesEligibility> AddRulesEligibility(RulesEligibility rulesEligibility);
        Task UpdateRulesEligibility(RulesEligibility rulesEligibility);
        Task DeleteRulesEligibility(int rulesEligibilityID);
    }
}
