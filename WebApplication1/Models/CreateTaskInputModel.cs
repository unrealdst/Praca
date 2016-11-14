using ScrumTableService.Common;

namespace WebApplication1.Models
{
    public class CreateTaskInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskType TaskType { get; set; }

        public int? ProjectId { get; set; }

        public string Users { get; set; }
    }
}