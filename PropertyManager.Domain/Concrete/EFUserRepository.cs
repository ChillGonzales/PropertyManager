using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public async Task<CreateUserResponseCode> CreateUserAsync(User userRequest)
        {
            userRequest.AccountCreationTS = DateTime.Now;
            userRequest.EmailConfirmed = "0";
            await Task.Run(new Func<>)
            context.Users.Add(userRequest);
            context.SaveChanges();
            return CreateUserResponseCode.Success;
        }
    }
}
