using Epam.Users_and_Award.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Users_and_Awards.BLL.Interfaces
{
    public interface IAwardLogic
    {
        void Add(string title);

        Award GetAwardById(int id);
        IEnumerable<Award> GetAll();

        void DeleteById(int id);

        void Update(int id, string title);

    }
}
