using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartConfig.Client.Services
{
    public interface IJurisdictionDataService
    {
        Task<IEnumerable<Jurisdiction>> GetAllJurisdictions();
        Task<Jurisdiction> GetJurisdictionById(int jurisdictionId);


    }
}
