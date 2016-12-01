using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using ProjectsService.DomainModel;
using ScrumTableService.DomainModels;
using ScrumTableService.DomainModels.Tasks;
using ScrumTableService.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.CommonModels;
using WebApplication1.Models.TasksViewModels;
using ScrumTableViewModel = WebApplication1.Models.TasksViewModels.ScrumTableViewModel;

namespace WebApplication1.Controllers
{
    public class ScrumTableController : BaseController
    {
        private readonly IScrumTableService ScrumTableService;
        private readonly IMapper mapper;

        public ScrumTableController(IScrumTableService scrumTableService)
        {
            ScrumTableService = scrumTableService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BugDomainModel, BugViewModel>();
                cfg.CreateMap<ImprovmentDomainModel, ImprovmentViewModel>();
                cfg.CreateMap<QuestionsDomainModel, QuestionViewModel>();
                cfg.CreateMap<TaskDomainModel, TaskViewModel>();
                cfg.CreateMap<CreateTaskInputModel, AddTaskDomainModel>()
                    .ForMember(dest => dest.ProjectId, opts => opts.MapFrom(src => src.Projects))
                    .ForMember(dest => dest.AssigneId, opts => opts.MapFrom(src => src.Users));
                cfg.CreateMap<CreateTaskInputModel, CreateTaskViewModel>();
                cfg.CreateMap<DropDownItemListDomainModel<string, string>, DropDownListItemViewModel<string, string>>();
                cfg.CreateMap<DropDownItemListDomainModel<int, string>, DropDownListItemViewModel<int, string>>();
                cfg.CreateMap<CreateTaskViewModelDateDomainModel, CreateTaskViewModel>()
                    .ForMember(dest => dest.Projects,opts => opts.MapFrom(src => src.Projects))
                    .ForMember(dest => dest.Users,opts => opts.MapFrom(src => src.Users));
                cfg.CreateMap<BaseTaskDomainModel, BaseTaskViewModel>();
            });
            mapper = config.CreateMapper();
        }
        // GET: ScrumTable
        public ActionResult Index(int projectId)
        {
            IEnumerable<BaseTaskDomainModel> tasks = ScrumTableService.GetTasks(projectId);
            var viewModel = new ScrumTableViewModel
            {
                Tasks = mapper.Map<IEnumerable<BaseTaskViewModel>>(tasks)
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(CreateTaskViewModel viewModel, int? projectId = null,bool inputNull = true)
        {
            if (inputNull)
            {
                CreateTaskViewModelDateDomainModel doaminModel = ScrumTableService.GetValueToViewModel(projectId ?? 0);
                viewModel = mapper.Map<CreateTaskViewModel>(doaminModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateTaskInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var addTaskDomainModel = mapper.Map<AddTaskDomainModel>(inputModel);
                
                ScrumTableService.AddTask(addTaskDomainModel, User.Identity.GetUserId());
                return RedirectToAction("ProjectsList", "ProjectLists");
            }

            var recritedModel = mapper.Map<CreateTaskViewModel>(inputModel);
            return RedirectToAction("Create", new { inputModel = recritedModel, inputModel.Projects, inputNull = false });
        }
    }
}