﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DbContext.Models;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Repositories
{
    public class ProjectRepositorie : IProjectRepositorie
    {
        private readonly ContextEntities dbContext;

        public ProjectRepositorie(ContextEntities context)
        {
            dbContext = context;
        }

        public IQueryable<ProjectStorageModel> GetProjects()
        {
            return dbContext
                .Project
                .Select(MappingProjectToStorageModel);
        }

        public ProjectStorageModel GetProject(int id)
        {
            return dbContext
                .Project
                .Where(x => x.Id == id)
                .Select(MappingProjectToStorageModel)
                .First();
        }

        public void AddProject(ProjectStorageModel project)
        {
            var dbProject = new Project()
            {
                Id = project.Id,
                Name = project.Name,
                ProjectOwnerId = project.ProjectOwnerId,
                ClientId = project.ClientId
            };

            dbContext.Project.AddOrUpdate(dbProject);
            dbContext.SaveChanges();
        }

        private static Expression<Func<Project, ProjectStorageModel>> MappingProjectToStorageModel => 
            x => new ProjectStorageModel()
        {
            Id = x.Id,
            Name = x.Name,
            ProjectOwnerId = x.ProjectOwnerId,
            ClientId = x.ClientId ?? 0
        };
    }
}