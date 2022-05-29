using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransactionRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Required!")]
        public double Amount { get; set; }

        public int Pin { get; set; }
    }
    public class Transfer
    {
        public Guid _id { get; set; }

        public double Debit { get; set; }

        public double Credit { get; set; }

        public DateTime dateTime { get; set; }
    }
}
