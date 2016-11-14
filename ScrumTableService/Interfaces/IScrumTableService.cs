using System.Collections.Generic;
using ScrumTableService.DomainModels;
using ScrumTableService.DomainModels.Tasks;

namespace ScrumTableService.Interfaces
{
    public interface IScrumTableService
    {
        IEnumerable<BaseTaskDomainModel> GetTasks(int projectId);
        void AddTask(AddTaskDomainModel addTaskDomainModel);
        CreateTaskViewModelDateDomainModel GetValueToViewModel(int? projectId);
    }
}