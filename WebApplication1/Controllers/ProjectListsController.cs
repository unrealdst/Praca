using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjectsService.DomainModel;
using ProjectsService.Interfaces;
using WebApplication1.Views;

namespace WebApplication1.Controllers
{
    public class ProjectListsController : Controller
    {
        private readonly IProjectListService projectListService;
        private readonly IMapper mapper;

        public ProjectListsController(IProjectListService projectListService)
        {
            this.projectListService = projectListService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDomainModel, ProjectViewModel>();
            });
            mapper = config.CreateMapper();
        }

        public ActionResult ProjectsList()
        {
            
            var projects = projectListService.GetAllProjects();
            var result = mapper.Map<IEnumerable<ProjectViewModel>>(projects);
            return View(result);
        }
    }
}