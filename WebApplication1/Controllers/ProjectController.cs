using System.Web.Mvc;
using AutoMapper;
using ProjectsService.DomainModel;
using ProjectsService.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectListService projectListService;
        private readonly IMapper mapper;

        public ProjectController(IProjectListService projectListService)
        {
            this.projectListService = projectListService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDomainModel, ProjectDetailViewModel>();
            });
            mapper = config.CreateMapper();
        }

        public ActionResult Project(int projectId)
        {
            var project = projectListService.GetProject(projectId);
            var viewModel = mapper.Map<ProjectDetailViewModel>(project);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Create(ProjectInputModel project)
        {
            if (ModelState.IsValid)
            {
                
            }
            return null;
        }
    }
}