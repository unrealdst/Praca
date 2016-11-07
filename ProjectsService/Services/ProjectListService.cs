using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Models;
using ProjectsService.DomainModel;
using ProjectsService.Interfaces;

namespace ProjectsService.Services
{
    public class ProjectListService : IProjectListService
    {
        private readonly IProjectReadOnlyRepositorie projectReadOnlyRepositorie;
        private readonly IMapper mapper;

        public ProjectListService(IProjectReadOnlyRepositorie projectReadOnlyRepositorie)
        {
            this.projectReadOnlyRepositorie = projectReadOnlyRepositorie;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectStorageModel, ProjectDomainModel>();
            });
            mapper = config.CreateMapper();
        }
      

        public IEnumerable<ProjectDomainModel> GetAllProjects()
        {
            var projects = projectReadOnlyRepositorie.GetProjects().ToList();
            return mapper.Map<IEnumerable<ProjectDomainModel>>(projects);
        }
    }
}