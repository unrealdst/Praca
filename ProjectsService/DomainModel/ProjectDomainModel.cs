﻿namespace ProjectsService.DomainModel
{
    public class ProjectDomainModel
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string OwnerName { get; set; }

        public string ProjectOwnerId { get; set; }

        public string ClientName { get; set; }

        public int ClientId { get; set; }
    }
}