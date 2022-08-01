using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChangePassword
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Required!")]
        public string oldPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required!")]
        public string newPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required!")]
        [Compare(nameof(newPassword), ErrorMessage = "Password Does Not Match!")]
        public string confirmPassword { get; set; }
    }
}
