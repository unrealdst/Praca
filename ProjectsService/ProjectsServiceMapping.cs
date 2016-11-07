using AutoMapper;
using ProjectsRepositorie.Models;
using ProjectsService.DomainModel;

namespace ProjectsService
{
    public class ProjectsServiceMapping
    {
        public MapperConfiguration CreateMap()
        {
           return new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<ProjectStorageModel, ProjectDomainModel>();
           });            
        }
    }
}