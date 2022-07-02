using BusinessManager;
using DataAccess.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace IPay.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly AdminManager manager;
        public AdminController(IRepository repository)
        {
            manager=new AdminManager(repository);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return View(manager.Get());
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
          var user=  manager.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserRequest user)
        {
           
              int res=  manager.Update(user);
                if (res>0)
                {
                if ()
                {

                }
                    ViewBag.Message = "User Updated Successfully";
                }

                else
                {
                    ViewBag.Error = "There Is Some Issue While Updating The User Please Try After Some Time";
                }
            
            return RedirectToAction("GetAll");
        }

        [HttpGet("ActiveAndInactive")]
        public IActionResult ActiveAndInactive(Guid id)
        {
            manager.UpdateStatus(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
