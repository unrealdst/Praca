using System.Web.Mvc;
using AutoMapper;
using ProjectsService.DomainModel;
using ProjectsService.Interfaces;
using WebApplication1.Views;

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
                cfg.CreateMap<ProjectDomainModel, ProjectViewModel>();
            });
            mapper = config.CreateMapper();
        }

        public ActionResult Project(int projectId)
        {
            var project = projectListService.GetProject(projectId);
            var viewModel = mapper.Map<ProjectViewModel>(project);
            return View(viewModel);
        }
    }
}