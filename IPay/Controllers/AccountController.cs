﻿using BusinessManager;
using DataAccess.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace IPay.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly AccountManager accountManager= null;
        private readonly UserManager userManager ;
        public AccountController(IRepository repository)
        {
            accountManager = new AccountManager(repository);
            userManager = new UserManager(repository);
        }


        [HttpGet("sendMoney")]
        public IActionResult SendMoney()
        {
            return View();
        }

        [HttpPost("sendMoney")]
        public IActionResult SendMoney(Guid id,TransactionRequest transaction)
        {
            string r = transaction.Pin.ToString();
            if (User.GetUserPin() == r && transaction.Email!=User.GetUserEmail())
            {
                LoginResponse receiver = accountManager.Find(id,transaction);

                if (!receiver.HasError)
                {
                    Transfer transactionResponse = new Transfer();
                    transactionResponse._id = receiver.Id;
                    transactionResponse.Credit = transaction.Amount;
                    accountManager.UpdateCreditor(transactionResponse);
                    ViewBag.Success = $"Amount Of Rupees {transaction.Amount} Is Transferred To {receiver.Email}";
                    return View();
                }
                else
                {
                    ViewBag.Error = "You Cannot Make Transaction as You Have Less Amount";
                    return View();
                }
                
            }
            else
            {
                ViewBag.Error = "Invalid Credencials";
                return View();
            }
        }

        [HttpGet("profile")]
        public IActionResult Profile(Guid id)
        {
           var user= accountManager.GetProfile(id);
            return View(user);
        }


        [HttpGet("changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(Guid id ,ChangePassword change)
        {
           int res= accountManager.changePassword(id,change);
            if (res>0)
            {
                ViewBag.Message = "Password Changed Successfully";
            }
            else
            {
                ViewBag.Error = "Password Does Not Match";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
          var res=  userManager.GetUserTransaction(User.GetUserId()).OrderBy(x => x.dateTime.Month).OrderBy(x=>x.dateTime.Date).OrderBy(x=>x.dateTime.Hour).OrderBy(x=>x.dateTime.Minute).OrderBy(x=>x.dateTime.Second);
            ViewBag.Balance = accountManager.GetBalance(User.GetUserId());
            return View(res);
        }


       


        }
    }

