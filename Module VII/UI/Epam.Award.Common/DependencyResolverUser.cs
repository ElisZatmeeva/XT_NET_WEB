using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.User_and_Award.BLL;
using Epam.User_and_Award.DAL;
using Epam.User_and_Award.DAL.Interfaces;
using Users_and_Awards.BLL.Interfaces;


namespace Epam.Users_and_User.Common
{
    public static class DependencyResolverUser
    {
        private static readonly IUserLogic _userLogic;
        private static readonly IUserDao _userDao;

        public static IUserLogic UserLogic => _userLogic;
        public static IUserDao UserDao => _userDao;

        static DependencyResolverUser()
        {
            _userDao = new UserDao();
            _userLogic = new UserLogic(_userDao);
        }
    }
}
