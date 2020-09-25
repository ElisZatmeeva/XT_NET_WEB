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
        void Add(string name, int age, DateTime DateOfBirth, string password);

        User GetUserById(int id);
        User GetUserByName(string name);

        void DeleteById(int id);

        void Update(int id, string name, int age, DateTime DateOfBirth);

        string AddImage(int id, string filename);

        IEnumerable<User> GetAll();
    }
}
