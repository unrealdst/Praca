using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjectsRepositorie.Interfaces;
using ScrumTableRepositorie.Interfaces;
using ScrumTableRepositorie.Models;
using ScrumTableService.Common;
using ScrumTableService.DomainModels;
using ScrumTableService.DomainModels.Tasks;
using ScrumTableService.Interfaces;
using UsersRepositories.Interfaces;

namespace ScrumTableService.Services
{
    public class ScrumTableService : IScrumTableService
    {
        private readonly IMapper mapper;
        private readonly ITaskRepositorie taskRepositorie;
        private readonly IUserRepositorie userRepositorie;
        private readonly IProjectRepositorie projectRepositorie;

        public ScrumTableService(ITaskRepositorie taskRepositorie, IUserRepositorie userRepositorie, IClientRepositorie clientRepositorie, IProjectRepositorie projectRepositorie)
        {
            this.taskRepositorie = taskRepositorie;
            this.userRepositorie = userRepositorie;
            this.projectRepositorie = projectRepositorie;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskStorageModel, BugDomainModel>();
                cfg.CreateMap<TaskStorageModel, ImprovmentDomainModel>();
                cfg.CreateMap<TaskStorageModel, QuestionsDomainModel>();
                cfg.CreateMap<TaskStorageModel, TaskDomainModel>();
                cfg.CreateMap<AddTaskDomainModel, TaskStorageModel>();
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

        public void AddTask(AddTaskDomainModel addTaskDomainModel, string reporterId)
        {
            addTaskDomainModel.ReporterId = reporterId;
            var storageModelTask = mapper.Map<TaskStorageModel>(addTaskDomainModel);
            taskRepositorie.InsertTask(storageModelTask);
        }

        public CreateTaskViewModelDateDomainModel GetValueToViewModel(int? projectId)
        {
            var result = new CreateTaskViewModelDateDomainModel
            {
                Projects = projectRepositorie.GetProjects().ToList().Select(x => new DropDownItemListDomainModel<int, string>()
                {
                    Id = x.Id,
                    Value = x.Name
                }),
                Users = userRepositorie.GetUsers().ToList().Select(x => new DropDownItemListDomainModel<string, string>()
                {
                    Id = x.Id,
                    Value = x.UserName
                })
            };

            return result;

        }
    }
}