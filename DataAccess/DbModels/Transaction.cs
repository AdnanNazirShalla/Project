using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbModels
{
    public class BankTransaction
    {
        
        public Guid Id { get; set; }

        public double Debit { get; set; }

        public double Credit { get; set; }

        public DateTime dateTime { get; set; }

        public Guid userId { get; set; }

        [ForeignKey(nameof(userId))]
        public User User { get; set; }
    }
}
