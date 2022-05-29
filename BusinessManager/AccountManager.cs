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

        
    }
}
