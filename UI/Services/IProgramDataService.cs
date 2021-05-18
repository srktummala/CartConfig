using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IProgramDataService
    {
        Task<IEnumerable<Programs>> GetAllPrograms();
        Task<Programs> GetProgramById(int programId);


    }
}
