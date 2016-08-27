using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Concrete
{
    public class EFPreUserRepository : IPreUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<PreUser> PreUsers
        {
            get
            {
                return context.PreUsers;
            }
        }

        public PreUserResponseCode Add(PreUser user)
        {
            user.AccountCreationTS = DateTime.Now;
            user.EmailConfirmed = "0";
            context.PreUsers.Add(user);
            context.SaveChanges();
            return PreUserResponseCode.Success;
        }
    }
}
