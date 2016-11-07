using System.Collections.Generic;
using ProjectsService.DomainModel;

namespace ProjectsService.Interfaces
{
    public interface IProjectListService
    {
        IEnumerable<ProjectDomainModel> GetAllProjects();
    }
}