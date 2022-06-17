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
                request.userStatus = userRequest.userStatus;
                request.userRole = userRequest.userRole;
                request.Balance = userRequest.Balance;
                userRequests.Add(request);
            }
            return userRequests;
        }
    }
}
