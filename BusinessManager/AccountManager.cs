using DataAccess.DataRepository;
using DataAccess.DbModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager
{
    public class AccountManager
    {
        private readonly IRepository repository;
        public AccountManager(IRepository repository)
        {
            this.repository = repository;
        }


        public LoginResponse Find(TransactionRequest transaction)
        {
            BankTransaction bankTransaction = new BankTransaction();
            LoginResponse loginResponse = new LoginResponse();
            User sender = repository.FindBy<User>(x => x.Id == transaction.Id).FirstOrDefault();
            
            bankTransaction.Id=Guid.NewGuid();
            bankTransaction.Debit = transaction.Amount;
            bankTransaction.userId= sender.Id;
            bankTransaction.dateTime = DateTime.Now;
            User receiver = repository.FindBy<User>(x => x.Email == transaction.Email).FirstOrDefault();
            if (receiver != null)
            {
                sender.Balance = sender.Balance - transaction.Amount;
              var a=  repository.AddandSave<BankTransaction>(bankTransaction);
              var res=  repository.UpdateAndSave(sender);

                loginResponse.Id = receiver.Id;
                loginResponse.Email = receiver.Email;
                loginResponse.Balance = receiver.Balance;
                loginResponse.Gender = receiver.Gender;
                loginResponse._password = receiver.Password;
                loginResponse.userRole = receiver.userRole;
                loginResponse.userStatus = receiver.userStatus;
                loginResponse.Name = receiver.Name;
                loginResponse.date = receiver.Date;
                loginResponse._pin = receiver.Pin;

            }
            return loginResponse;
        }

        public int UpdateCreditor(Transfer transfer)
        {
            BankTransaction bankTransaction = new BankTransaction();
            User user = repository.FindBy<User>(x=>x.Id==transfer._id).FirstOrDefault();
           
            bankTransaction.Id = Guid.NewGuid();
            bankTransaction.userId = user.Id;
            bankTransaction.Credit = transfer.Credit;
            bankTransaction.dateTime = DateTime.Now;
            repository.AddandSave<BankTransaction>(bankTransaction);
            user.Balance += transfer.Credit;
            int res = repository.UpdateAndSave<User>(user);
         
            return res;
        }

    }
}
