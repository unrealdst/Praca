using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreateProjectInputModel
    {
        public string ProjectOwners { get; set; }

        [MinLength(10)]
        public string ProjectName { get; set; }

        public int Clients { get; set; }
    }
}