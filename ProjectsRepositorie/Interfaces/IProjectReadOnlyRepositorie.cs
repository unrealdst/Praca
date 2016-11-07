using System.Linq;
using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Interfaces
{
    public interface IProjectReadOnlyRepositorie
    {
        IQueryable<ProjectStorageModel> GetProjects();

        ProjectStorageModel GetProject(int id);
    }
}