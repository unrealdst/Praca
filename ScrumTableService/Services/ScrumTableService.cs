using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ScrumTableRepositorie.Interfaces;
using ScrumTableRepositorie.Models;
using ScrumTableService.Common;
using ScrumTableService.DomainModels.Tasks;
using ScrumTableService.Interfaces;
using TaskStatus = ScrumTableService.Common.TaskStatus;

namespace ScrumTableService.Services
{
    public class ScrumTableService : IScrumTableService
    {
        private readonly IMapper mapper;
        private readonly ITaskRepositorie taskRepositorie;

        public ScrumTableService(ITaskRepositorie taskRepositorie)
        {
            this.taskRepositorie = taskRepositorie;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskStorageModel, BugDomainModel>();
                cfg.CreateMap<TaskStorageModel, ImprovmentDomainModel>();
                cfg.CreateMap<TaskStorageModel, QuestionsDomainModel>();
                cfg.CreateMap<TaskStorageModel, TaskDomainModel>();
            });
            mapper = config.CreateMapper();
        }

        public IEnumerable<BaseTaskDomainModel> GetTasks(int projectId)
        {
            var tasks = taskRepositorie.GetTasksForProject(projectId);
            var result = new List<BaseTaskDomainModel>();
            foreach (var task in tasks)
            {
                switch (task.Type)
                {
                    case (int)TaskType.Task:
                        result.Add(mapper.Map<TaskDomainModel>(task));
                        break;
                    case (int) TaskType.Question:
                        result.Add(mapper.Map<QuestionsDomainModel>(task));
                        break;
                    case (int)TaskType.Bug:
                        result.Add(mapper.Map<BugDomainModel>(task));
                        break;
                    case (int)TaskType.Improvment:
                        result.Add(mapper.Map<ImprovmentDomainModel>(task));
                        break;
                }
            }
    
            return result;
        }
    }
}