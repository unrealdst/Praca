using System.Collections.Generic;

namespace ScrumTableService.DomainModels
{
    public class AddTaskDomainModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string ReporterId { get; set; }
        public string AssigneId { get; set; }
        public int ProjectId { get; set; }
    }
}
