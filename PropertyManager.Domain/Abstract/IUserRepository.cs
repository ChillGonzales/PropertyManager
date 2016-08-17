using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        //Task<ResponseCode> CreateUserAsync(User userRequest);
    }
}
