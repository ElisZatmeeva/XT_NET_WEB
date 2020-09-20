using Epam.Users_and_Award.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Users_and_Awards.BLL.Interfaces
{
    public interface IUserLogic
    {
        /*int Add(User user);*/
        void Add(string name, int age, DateTime DateOfBirth);

        User GetUserById(int id);

        void DeleteById(int id);

        IEnumerable<User> GetAll();
    }
}
