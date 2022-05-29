using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class  TransactionResponse
    {
        public Guid _id { get; set; }

        public double Debit { get; set; }

        public double Credit { get; set; }

        public DateTime dateTime { get; set; }
    }
}
