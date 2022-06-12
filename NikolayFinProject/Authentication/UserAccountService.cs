using System.Collections.Generic;
using System.Linq;

namespace NikolayFinProject.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _users;
        public UserAccountService()
        {
            _users = UserAccount.GetAllUserAccountFromDB();
            //    new List<UserAccount>
            //{
            //    new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrator" },
            //    new UserAccount{ UserName = "user", Password = "user", Role = "User" }
            //};
        }

        public UserAccount? GetByUserName(string userLogin)
        {
            return _users.FirstOrDefault(x => x.UserLogin == userLogin);
        }
    }
}
