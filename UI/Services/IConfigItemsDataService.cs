using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IConfigItemsDataService
    {
        Task<IEnumerable<ConfigItems>> GetAllConfigItems();
        Task<ConfigItems> GetConfigItemsDetails(int ConfigItemsId);
        Task<ConfigItems> GetConfigItemsById(int ConfigItemsId);
        Task<ConfigItems> AddConfigItems(ConfigItems configItems);
        Task UpdateConfigItems(ConfigItems configItems);
    }
}
