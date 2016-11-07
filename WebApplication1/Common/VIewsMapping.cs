using AutoMapper;
using ProjectsService.DomainModel;
using WebApplication1.Views;

namespace WebApplication1.Common
{
    public static class ViewsMapping
    {
        public static void CreateMap()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProjectDomainModel, ProjectViewModel>());
        }
    }
}