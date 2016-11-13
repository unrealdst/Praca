using ScrumTableService.Common;

namespace ScrumTableService.DomainModels.Tasks
{
    public class TaskDomainModel : BaseTaskDomainModel
    {
        public override int GetTaskType()
        {
            return (int) TaskType.Task;
        }
    }
}