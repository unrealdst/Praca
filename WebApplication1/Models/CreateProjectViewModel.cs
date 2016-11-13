using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CreateProjectViewModel
    {
        public List<UserViewModel> ProjectOwners { get; set; }
        public string DefaultUserId { get; set; }
        public int? DeafultClientId { get; set; }
    
        public string ProjectName { get; set; }

        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}