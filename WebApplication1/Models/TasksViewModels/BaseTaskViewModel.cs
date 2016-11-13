using ScrumTableService.Common;

namespace WebApplication1.Models.TasksViewModels
{
    public class BaseTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public string ReporterId { get; set; }
        public string AssigneId { get; set; }
    }
}