using System.Collections.Generic;
using WebApplication1.Models.TasksViewModels;

namespace WebApplication1.Models
{
    public class ScrumTableViewModel
    {
        public IEnumerable<BaseTaskViewModel> Tasks { get; set; }
    }
}