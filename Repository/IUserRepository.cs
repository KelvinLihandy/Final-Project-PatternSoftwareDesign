using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Repository
{
    public interface IUserRepository
    {
        MsUser GetUserById(int userId);
        void UpdatePassword(MsUser user, string newPassword);
    }
}
