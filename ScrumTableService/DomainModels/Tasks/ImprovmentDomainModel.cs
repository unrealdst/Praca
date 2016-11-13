using ScrumTableService.Common;

namespace ScrumTableService.DomainModels.Tasks
{
    public class ImprovmentDomainModel:BaseTaskDomainModel
    {
        public override int GetTaskType()
        {
            return (int)TaskType.Improvment;
        }
    }
}