using System.Collections.Generic;
using ScrumTableService.Common;
using WebApplication1.Models.CommonModels;

namespace WebApplication1.Models
{
    public class CreateTaskViewModel
    {
        public IEnumerable<DropDownListItemViewModel<int, string>> Projects { get; set; }

        public IEnumerable<DropDownListItemViewModel<string, string>> Users { get; set; } 

        public string Title { get; set; }

        public string Description { get; set; } 

        public TaskType TaskType { get; set; }

        public int? ProjectId { get; set; }
    }
}