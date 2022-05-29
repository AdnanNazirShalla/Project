using BusinessManager;
using DataAccess.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace IPay.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly AccountManager accountManager = null;
        public AccountController(IRepository repository)
        {
            accountManager = new AccountManager(repository);
        }


        [HttpGet("sendMoney")]
        public IActionResult SendMoney()
        {
            return View();
        }

        [HttpPost("sendMoney")]
        public IActionResult SendMoney(TransactionRequest transaction)
        {
            LoginResponse receiver = accountManager.Find(transaction);
            
            Transfer transactionResponse = new Transfer();
            transactionResponse._id = receiver.Id;
            transactionResponse.Credit = transaction.Amount;
            accountManager.UpdateCreditor(transactionResponse);
            return View();
        }

        //[HttpGet("TransferMoney")]
        //public IActionResult TransferMoney()
        //{
        //    return View();
        //}


        //[HttpPost("TransferMoney")]
        //public IActionResult TransferMoney(Transfer transfer)
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
