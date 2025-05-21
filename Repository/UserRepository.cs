using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Repository
{
    public class UserRepository : IUserRepository
    {
        private DatabaseJewel db = new DatabaseJewel();

        public MsUser GetUserById(int userId)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserID == userId);
        }

        public void UpdatePassword(MsUser user, string newPassword)
        {
            user.UserPassword = newPassword;
            db.SaveChanges();
        }
    }
}
