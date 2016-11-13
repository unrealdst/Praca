using System.Linq;
using DbContext.Models;
using ScrumTableRepositorie.Interfaces;
using ScrumTableRepositorie.Models;

namespace ScrumTableRepositorie.Repositories
{
    public class TaskRepositorie : ITaskRepositorie
    {
        private readonly ContextEntities dbContext;

        public TaskRepositorie(ContextEntities context)
        {
            dbContext = context;
        }

        public IQueryable<TaskStorageModel> GetTasksForProject(int projectId)
        {
            return dbContext
                .Task
                .Where(x => x.ProjectId == projectId)
                .Select(x => new TaskStorageModel()
            {
                Id = x.Id,
                Title = x.Title,
                AssigneId = x.AssigneId,
                Description = x.Description,
                ReporterId = x.ReporterId,
                Status = x.Status,
                Type = x.Type,
                ProjectId = x.ProjectId
            });
        }
    }
}