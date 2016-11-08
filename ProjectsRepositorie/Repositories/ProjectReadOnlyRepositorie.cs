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
        private readonly ContextEntities dbContext;

        public ProjectReadOnlyRepositorie(ContextEntities context)
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
                .Project
                .ProjectTo<ProjectStorageModel>();
        }

        public ProjectStorageModel GetProject(int id)
        {
            return dbContext
                .Project
                .ProjectTo<ProjectStorageModel>()
                .Single(x => x.Id == id);
        }
    }
}