using System.Linq;
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

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbContext.Models.Project, ProjectStorageModel>();
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