using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users_and_Award.Entities;

namespace Epam.User_and_Award.BLL.Interfaces
{
    public interface IUserLogic
    {
        /*User GenerateUser();*/
        int Add(User user);

        void DeleteById(Guid id);

        IEnumerable<User> GetAll();
    }
}
