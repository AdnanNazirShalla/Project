using DataAccess.ContextDb;
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
    public class AdminManager
    {

        private readonly IRepository repository = null;

            public AdminManager(IRepository repository)
               {
                 this.repository = repository;
               }

        public List<UserRequest> Get()
        {
           List<User> user= repository.GetAll<User>().ToList();
            List<UserRequest> userRequests = new List<UserRequest>();
            foreach (var userRequest in user)
            {
                UserRequest request = new UserRequest();
                request.Id=userRequest.Id;
                request.Name=userRequest.Name;
                request.Email=userRequest.Email;
                request.Gender=userRequest.Gender;
                request.userStatus = userRequest.userStatus;
                request.userRole = userRequest.userRole;
                request.Balance = userRequest.Balance;
                userRequests.Add(request);
            }
            return userRequests;
        }

        public UserRequest Find(Guid id)
        {
          User user=  repository.GetById<User>(id);

            UserRequest userRequest = new UserRequest();
            userRequest.Id=user.Id;
            userRequest.Name=user.Name;
            userRequest.Email=user.Email;
            userRequest._password=user.Password;
            userRequest.Gender=user.Gender;
            userRequest.userStatus = user.userStatus;
            userRequest.Balance= user.Balance;
            userRequest.userRole = user.userRole;
            userRequest.date = user.Date;
            userRequest._pin = user.Pin;
            return userRequest;
        }

        public int Update(UserRequest userRequest)
        {
            User user=new User()
            {
                Id=userRequest.Id,
                Name=userRequest.Name,
                Balance=userRequest.Balance,
                Email=userRequest.Email,
                Gender=userRequest.Gender,
                userStatus=userRequest.userStatus,
                userRole=userRequest.userRole,
                Password=userRequest._password,
                Pin=userRequest._pin,
                Date=userRequest.date
                
            };

           
           int res= repository.UpdateAndSave<User>(user);
            return res;
        }

        public int UpdateStatus(Guid id)
        {
            User user = repository.GetById<User>(id);
            if (user.userStatus==UserStatus.Active)
            {
                user.userStatus=UserStatus.Inactive;
            }
            else
            {
                user.userStatus=UserStatus.Active;
            }

            return repository.UpdateAndSave<User>(user);
        }
    }
}
