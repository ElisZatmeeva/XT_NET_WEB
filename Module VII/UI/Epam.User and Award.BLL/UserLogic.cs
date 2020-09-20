using Epam.User_and_Award.DAL.Interfaces;
using Epam.Users_and_Award.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_and_Awards.BLL.Interfaces;

namespace Epam.User_and_Award.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {

            _userDao = userDao;

        }

        public void Add(string name, int age, DateTime DateOfBirth)
        {
            _userDao.Add(name, age, DateOfBirth);
        }

        public User GetUserById(int id)
        {
            var user = _userDao.GetUserById(id);
            /*Console.WriteLine(user);*/
            return _userDao.GetUserById(id);

        }

        public void DeleteById(int id)
        {
            _userDao.DeleteById(id);

        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

    }
}
