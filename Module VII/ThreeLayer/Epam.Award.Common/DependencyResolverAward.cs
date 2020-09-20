using Epam.User_and_Award.BLL;
using Epam.User_and_Award.DAL;
using Epam.User_and_Award.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_and_Awards.BLL.Interfaces;

namespace Epam.Users_and_Award.Common
{
    public static class DependencyResolverAward
    {
        private static readonly IAwardLogic _awardLogic;
        private static readonly IAwardDao _awardDao;

        public static IAwardLogic AwardLogic => _awardLogic;
        public static IAwardDao AwardDao => _awardDao;

        static DependencyResolverAward()
        {
            _awardDao = new AwardDao();
            _awardLogic = new AwardLogic(_awardDao);
        }
    }
}
