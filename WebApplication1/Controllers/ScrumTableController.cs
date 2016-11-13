using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ScrumTableService.DomainModels.Tasks;
using ScrumTableService.Interfaces;
using WebApplication1.Models.TasksViewModels;

namespace WebApplication1.Controllers
{
    public class ScrumTableController : Controller
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
    }
}