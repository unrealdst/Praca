using System.Web.Mvc;
using AutoMapper;
using ProjectsRepositorie.Models;
using ProjectsService.DomainModel;
using ProjectsService.Interfaces;
using UsersRepositories.Models;
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
                cfg.CreateMap<CreateProjectInputModel, AddProjectDomainModel>();
                cfg.CreateMap<CreateProjectDomainModel, CreateProjectViewModel>();
                cfg.CreateMap<UserStorageModel, UserViewModel>()
                .ForMember(dest => dest.Name,opts => opts.MapFrom(src => src.UserName));
                cfg.CreateMap<ClientStorageModel, ClientViewModel>();
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
        public ActionResult Create(CreateProjectViewModel inputModel = null)
        {

            if (inputModel == null)
            {
                inputModel = mapper.Map<CreateProjectViewModel>(projectListService.GetValueToViewModel());
            }
            return View(inputModel);
        }

        [HttpPost]
        public ActionResult Create(CreateProjectInputModel project)
        {
            if (ModelState.IsValid)
            {
                var addProjectDomainModel = mapper.Map<AddProjectDomainModel>(project);
                projectListService.AddProject(addProjectDomainModel);
            }
            
            var recritedModel = new CreateProjectViewModel();
            return RedirectToAction("Create",new {inputModel = recritedModel});
        }
    }
}