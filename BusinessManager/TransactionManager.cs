using DataAccess.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager
{
    public class TransactionManager
    {
        private readonly IRepository repository = null;

        public TransactionManager(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
