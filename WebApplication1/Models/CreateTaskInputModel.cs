using System.ComponentModel.DataAnnotations;
using ScrumTableService.Common;

namespace WebApplication1.Models
{
    public class CreateTaskInputModel
    {
        [MaxLength(128)]
        public string Title { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public TaskType TaskType { get; set; }

        public int? Projects { get; set; }

        public string Users { get; set; }
    }
}