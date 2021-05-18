using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IStatusDataService
    {
        Task<IEnumerable<Status>> GetAllStatuses();
        Task<Status> GetStatusById(int statusId);


    }
}
