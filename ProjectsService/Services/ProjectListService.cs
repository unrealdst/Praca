using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Models;
using ProjectsService.DomainModel;
using ProjectsService.Interfaces;
using UsersRepositories.Interfaces;

namespace ProjectsService.Services
{
    public class ProjectListService : IProjectListService
    {
        private readonly IProjectRepositorie projectRepositorie;
        private readonly IUserRepositorie userRepositorie;
        private readonly IMapper mapper;

        public ProjectListService(
            IProjectRepositorie projectRepositorie,
            IUserRepositorie userRepositorie)
        {
            this.projectRepositorie = projectRepositorie;
            this.userRepositorie = userRepositorie;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectStorageModel, ProjectDomainModel>();
            });
            mapper = config.CreateMapper();
        }
      

        public IEnumerable<ProjectDomainModel> GetAllProjects()
        {
            var projects = projectRepositorie.GetProjects().ToList();
            return mapper.Map<IEnumerable<ProjectDomainModel>>(projects);
        }

        public ProjectDomainModel GetProject(int projectId)
        {
            var project = projectRepositorie.GetProject(projectId);
            var projectDomainModel = mapper.Map<ProjectDomainModel>(project);
            var owner = userRepositorie.GetUser(projectDomainModel.ProjectOwnerId);
            projectDomainModel.OwnerName = owner.UserName;
            return projectDomainModel;
        }
    }
}