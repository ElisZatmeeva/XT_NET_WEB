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

        IEnumerable<Award> GetAll();

    }
}
