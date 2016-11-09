using System.Collections.Generic;
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
        public ActionResult Create(CreateProjectViewModel inputModel = null)
        {
            inputModel = new CreateProjectViewModel()
            {
                Clients = new List<ClienViewModel>()
                {
                    new ClienViewModel() {Id = 1,Name = "asdf"},
                    new ClienViewModel() {Id = 2,Name = "asdfasdasd"},
                    new ClienViewModel() {Id = 3,Name = "asdczxcf"}
                },
                ProjectOwners = new List<UserViewModel>()
                {
                    new UserViewModel() {Id ="asada",Name="dsadas" },
                    new UserViewModel() {Id ="as1ada",Name="dsad213as" },
                    new UserViewModel() {Id ="as1ada",Name="dsaddsadaas" }
                }
            };
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