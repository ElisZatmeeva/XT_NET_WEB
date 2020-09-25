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

        public void Add(string name, int age, DateTime DateOfBirth, string password)
        {
            _userDao.Add(name, age, DateOfBirth, password);
        }

        public string AddImage(int id, string filename)
        {
            _userDao.AddImage(id, filename);
            return filename;
        }

        public void Update(int id, string name, int age, DateTime DateOfBirth)
        {
            _userDao.Update(id, name, age, DateOfBirth);
        }

        public User GetUserById(int id)
        {

            return _userDao.GetUserById(id);

        }

        public User GetUserByName(string name)
        {

            return _userDao.GetUserByName(name);

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
