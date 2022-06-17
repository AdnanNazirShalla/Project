using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class UserRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Required!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required!")]
        public Gender Gender { get; set; }



        public UserRole userRole { get; set; }

        public UserStatus userStatus { get; set; }

        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string _password { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Compare(nameof(_password), ErrorMessage = "Password Does Not Match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]

        public string _confirmPassword { get; set; }

        [Required(ErrorMessage = "Required!")]
        public double Balance { get; set; }


        [Required(ErrorMessage = "Required!")]
        //[MinLength(4,ErrorMessage ="The Minimum Length Of Pin Should Be 4 Digits")]
        //[MaxLength(6,ErrorMessage ="The Maximum Length Of Pin Should Be 6 Digits")]
        public int _pin { get; set; }

        public DateTime date { get; set; }
    }





    public class LoginRequest
    {
        [Required(ErrorMessage = "Required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }

    public class LoginResponse : UserRequest
    {
        public bool HasError { get; set; }
    }
}