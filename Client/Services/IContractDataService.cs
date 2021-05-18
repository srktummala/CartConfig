using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartConfig.Client.Services
{
    public interface IContractDataService
    {
        Task<IEnumerable<Contract>> GetAllContracts();
        Task<Contract> GetContractById(int contractId);


    }
}
