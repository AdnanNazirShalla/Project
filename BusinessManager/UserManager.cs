using DataAccess.DataRepository;
using DataAccess.DbModels;
using Model;

namespace BusinessManager
{
    public class UserManager
    {
        private readonly IRepository repository = null;
        public UserManager(IRepository repository)
        {
            this.repository = repository;
        }

        public int CreateUser(UserRequest userRequest)
        {
            bool exists=repository.IsExist<User>(x=>x.Email==userRequest.Email);
            if (!exists)
            {
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = userRequest.Name,
                    Email = userRequest.Email,
                    Password = userRequest._password,
                    Gender = userRequest.Gender,
                    Pin = userRequest._pin,
                    userStatus = UserStatus.Active,
                    userRole = UserRole.Customer,
                    Balance=0,
                    Date = DateTime.Now,
                };
                return repository.AddandSave<User>(user);
            }
            else
            {
                return 0;
            }
        }


        public int UpdateUser(UserRequest userRequest)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest._password,
                Gender = userRequest.Gender,
                Pin = userRequest._pin,
                userRole = userRequest.userRole,
                Balance = userRequest.Balance,
                Date = DateTime.Now,
            };
            return repository.UpdateAndSave<User>(user);
        }


        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            User user = repository.FindBy<User>(x => x.Email == loginRequest.Email).FirstOrDefault();

            if (user == null)
            {
                loginResponse.HasError = true;
                return loginResponse;
            }
            else if (loginRequest.Password != user.Password)
            {
                loginResponse.HasError = true;
                return loginResponse;
            }

            else
            {
                loginResponse.Id = user.Id;
                loginResponse.Name = user.Name;
                loginResponse.Email = user.Email;
                loginResponse.Balance = user.Balance;
                return loginResponse;
            }
        }
    }
}