using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbModels
{
    public class User
    {
   
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Pin { get; set; }

        public UserStatus userStatus { get; set; }

        public double Balance { get; set; }

        public UserRole userRole { get; set; }

        public Gender Gender { get; set; }

        public DateTime Date { get; set; }

        public ICollection<BankTransaction> bankTransaction { get; set; }
    }
}
