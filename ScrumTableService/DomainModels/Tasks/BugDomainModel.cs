using ScrumTableService.Common;

namespace ScrumTableService.DomainModels.Tasks
{
    public class BugDomainModel : BaseTaskDomainModel
    {
        public override int GetTaskType()
        {
            return (int)TaskType.Bug;
        }
    }
}