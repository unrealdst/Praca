using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DbContext;
using DbContext.Models;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Repositories
{
    public class ProjectReadOnlyRepositorie : IProjectReadOnlyRepositorie
    {
        private readonly Context dbContext;

        public ProjectReadOnlyRepositorie(Context context)
        {
            dbContext = context;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Project, ProjectStorageModel>();
            });
        }

        public IQueryable<ProjectStorageModel> GetProjects()
        {
            return dbContext
                .Projects
                .ProjectTo<ProjectStorageModel>();
        }

        public ProjectStorageModel GetProject(int id)
        {
            return dbContext
                .Projects
                .ProjectTo<ProjectStorageModel>()
                .Single(x => x.Id == id);
        }
    }
}