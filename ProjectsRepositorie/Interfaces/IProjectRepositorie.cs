using System.Linq;
using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Interfaces
{
    public interface IProjectRepositorie
    {
        IQueryable<ProjectStorageModel> GetProjects();

        ProjectStorageModel GetProject(int id);
    }
}