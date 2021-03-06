using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IFarmBillDataService
    {
        Task<IEnumerable<FarmBill>> GetAllFarmBills();
        Task<FarmBill> GetFarmBillById(int farmBillId);


    }
}
