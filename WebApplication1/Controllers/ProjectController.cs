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
                    .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.UserName));
                cfg.CreateMap<ClientStorageModel, ClientViewModel>();
                cfg.CreateMap<CreateProjectInputModel, CreateProjectViewModel>()
                    .ForMember(dest => dest.ProjectName, opts => opts.MapFrom(src => src.ProjectName))
                    .ForMember(dest => dest.DeafultClientId, opts => opts.MapFrom(src => src.Clients))
                    .ForMember(dest => dest.DefaultUserId, opts => opts.MapFrom(src => src.ProjectOwners))
                    .ForAllOtherMembers(x => x.Ignore());
                cfg.CreateMap<CreateProjectInputModel, AddProjectDomainModel>()
                    .ForMember(dest => dest.ProjectOwnerId, opts => opts.MapFrom(src => src.ProjectOwners))
                    .ForMember(dest => dest.ClientId, opts => opts.MapFrom(src => src.Clients));
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
        public ActionResult Create(CreateProjectViewModel viewModel, bool inputNull = true)
        {
            if (inputNull)
            {
                viewModel = mapper.Map<CreateProjectViewModel>(projectListService.GetValueToViewModel());
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateProjectInputModel project)
        {
            if (ModelState.IsValid)
            {
                var addProjectDomainModel = mapper.Map<AddProjectDomainModel>(project);
                projectListService.AddProject(addProjectDomainModel);
                return RedirectToAction("ProjectsList", "ProjectLists");
            }

            var recritedModel = mapper.Map<CreateProjectViewModel>(project);
            return RedirectToAction("Create", new {inputModel = recritedModel, inputNull = false});
        }
    }
}