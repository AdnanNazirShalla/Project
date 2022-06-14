using BusinessManager;
using DataAccess.DataRepository;
using Microsoft.AspNetCore.Mvc;

namespace IPay.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminManager manager;
        public AdminController(IRepository repository)
        {
            manager=new AdminManager(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(manager.Get());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
