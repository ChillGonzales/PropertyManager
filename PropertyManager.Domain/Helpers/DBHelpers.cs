using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Helpers
{
    public static class DBHelpers
    {
        public static async Task<ResponseCode> CheckUser(IPreUserRepository userRepo, PreUser user)
        {
            var respCode = await Task.Run<ResponseCode>(new Func<ResponseCode>(() =>
            {
                if (userRepo.PreUsers.Any(x => x.Email.ToLower() == user.Email.ToLower()))
                {
                    return ResponseCode.EmailAlreadyInUse;
                }
                else if (userRepo.PreUsers.Any(x => x.PhoneNumber == user.PhoneNumber))
                {
                    return ResponseCode.PhoneNumberAlreadyInUse;
                }
                else
                {
                    return ResponseCode.Success;
                }
            }));

            return respCode;
        }
    }
}
