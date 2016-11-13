using ScrumTableService.Common;

namespace ScrumTableService.DomainModels.Tasks
{
    public class QuestionsDomainModel : BaseTaskDomainModel
    {
        public override int GetTaskType()
        {
            return (int)TaskType.Question;
        }
    }
}