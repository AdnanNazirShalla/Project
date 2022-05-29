using BusinessManager;
using DataAccess.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace IPay.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountManager accountManager = null;
        public AccountController(IRepository repository)
        {
            accountManager = new AccountManager(repository);
        }

       
        public IActionResult Index()
        {
            return View();
        }
    }
}
