using System.Linq;
using DbContext.Models;
using ScrumTableRepositorie.Models;

namespace ScrumTableRepositorie.Interfaces
{
    public interface ITaskRepositorie
    {
        IQueryable<TaskStorageModel> GetTasksForProject(int projectId);
    }
}