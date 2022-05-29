using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Gender:byte
    {
        Male=1,
        Female=2,
    }

    public enum UserStatus:byte
    {
        Active=1,
        Inactive=2,
    }

    public enum UserRole : byte
    {
        Admin = 1,
        Customer = 2
    }

    
}
