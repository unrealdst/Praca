using System;
using System.Collections.Generic;
using System.Linq;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Repositories
{
    public class ProjectReadOnlyRepositorie : IProjectReadOnlyRepositorie
    {
        public ProjectReadOnlyRepositorie()
        {
            
        }

        public IQueryable<ProjectStorageModel> GetProjects()
        {
            var result = new List<ProjectStorageModel>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new ProjectStorageModel()
                {
                    Name = $"Name{i}"
                });
            }

            return result.AsQueryable();
        }

        public ProjectStorageModel GetProject(int id)
        {
            var result = new List<ProjectStorageModel>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new ProjectStorageModel()
                {
                    Name = String.Format(@"Name{i}")
                });
            }

            return result.ElementAt(id);
        }
    }
}