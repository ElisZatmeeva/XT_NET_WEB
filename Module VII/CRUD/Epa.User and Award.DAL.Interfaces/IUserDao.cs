using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users_and_Award.Entities;

namespace Epam.User_and_Award.DAL.Interfaces
{
    public interface IUserDao
    {

        /* int Add(User user);*/
        void Add(string name, int age, DateTime DateOfBirth);

        User GetUserById(int id);

        void DeleteById(int id);

        void Update(int id, string name, int age, DateTime DateOfBirth);

        IEnumerable<User> GetAll();
      
    }
}
