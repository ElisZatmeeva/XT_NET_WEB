using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users_and_Award.Entities;

namespace Epam.User_and_Award.DAL.Interfaces
{
    public interface IAwardDao
    {
        void Add(string title);

        IEnumerable<Award> GetAll();

    }
}
