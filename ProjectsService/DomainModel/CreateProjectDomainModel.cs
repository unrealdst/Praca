using System.Collections.Generic;
using ProjectsRepositorie.Models;
using UsersRepositories.Models;

namespace ProjectsService.DomainModel
{
    public class CreateProjectDomainModel
    {
        public IEnumerable<UserStorageModel> ProjectOwners { get; set; }

        public IEnumerable<ClientStorageModel> Clients { get; set; }
    }
}