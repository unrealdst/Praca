using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ScrumTableService.DomainModels;
using ScrumTableService.DomainModels.Tasks;

namespace ScrumTableService.Interfaces
{
    public interface IScrumTableService
    {
        IEnumerable<BaseTaskDomainModel> GetTasks(int projectId);
    }
}