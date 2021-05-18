using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartConfig.Client.Services
{
    public interface IStatusDataService
    {
        Task<IEnumerable<Status>> GetAllStatuses();
        Task<Status> GetStatusById(int statusId);


    }
}
