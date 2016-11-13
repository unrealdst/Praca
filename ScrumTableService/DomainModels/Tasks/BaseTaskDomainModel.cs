using ScrumTableService.Common;

namespace ScrumTableService.DomainModels.Tasks
{
    public abstract class BaseTaskDomainModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public string ReporterId { get; set; }
        public string AssigneId { get; set; }

        public abstract int GetTaskType();
    }
}