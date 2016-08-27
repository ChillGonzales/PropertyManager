using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain
{
    public enum PreUserResponseCode
    {
        Success = 0,
        EmailAlreadyInUse = 1,
        PhoneNumberAlreadyInUse = 2
    }

    public enum CreateUserResponseCode
    {
        Success = 0,
        UserNotFound = 1,
        UserAlreadyInUse = 2
    }
}
