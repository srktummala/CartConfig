using CartConfig.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesEngine.UI.Services
{
    public interface IProgramComponentDataService
    {
        Task<IEnumerable<ProgramComponent>> GetAllProgramComponents();
        Task<ProgramComponent> GetProgramComponentById(int programComponentId);


    }
}
