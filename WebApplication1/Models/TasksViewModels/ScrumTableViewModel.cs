using System.Collections.Generic;

namespace WebApplication1.Models.TasksViewModels
{
    public class ScrumTableViewModel
    {
        public IEnumerable<BaseTaskViewModel> Tasks { get; set; }  
    }
}