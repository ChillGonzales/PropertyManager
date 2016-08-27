using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptSharp;

namespace PropertyManager.Domain.Helpers
{
    public static class DBHelpers
    {
        public static async Task<PreUserResponseCode> CheckUser(IPreUserRepository userRepo, PreUser user)
        {
            var respCode = await Task.Run<PreUserResponseCode>(new Func<PreUserResponseCode>(() =>
            {
                if (userRepo.PreUsers.Any(x => x.Email.ToLower() == user.Email.ToLower()))
                {
                    return PreUserResponseCode.EmailAlreadyInUse;
                }
                else if (userRepo.PreUsers.Any(x => x.PhoneNumber == user.PhoneNumber))
                {
                    return PreUserResponseCode.PhoneNumberAlreadyInUse;
                }
                else
                {
                    return PreUserResponseCode.Success;
                }
            }));

            return respCode;
        }

        public static async Task<CreateUserResponseCode> CreateUser(IPreUserRepository preUserRepo, IUserRepository userRepo, User user)
        {
            var respCode = await Task.Run<CreateUserResponseCode>(new Func<CreateUserResponseCode>(() =>
                {
                    if (userRepo.Users.Any(x => x.Email.ToLower() == user.Email.ToLower() && x.FirstName.ToLower() == user.FirstName.ToLower() && x.LastName.ToLower() == user.LastName.ToLower()))
                    {
                        return CreateUserResponseCode.UserAlreadyInUse;
                    }
                    else if (preUserRepo.PreUsers.Any(x => x.Email.ToLower() == user.Email.ToLower() && x.FirstName.ToLower() == user.FirstName.ToLower() && x.LastName.ToLower() == user.LastName.ToLower()))
                    {
                        userRepo.CreateUserAsync(user);
                        return CreateUserResponseCode.Success;
                    }
                    else { return CreateUserResponseCode.UserNotFound; }
                }));

            return respCode;
        }

        public static async Task<byte[]> CreateNewSalt()
        {
            var salt = await Task.Run(new Func<string>(() => { return CryptSharp.Crypter.Blowfish.GenerateSalt(); }));
            return Encoding.ASCII.GetBytes(salt);
        }
    }
}
