using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Award.BLL.Interface
{
    public interface IAwardLogic
    {
        int Add(Epam.Users_and_Award.Entities.Award award);
        IEnumerable<Epam.Users_and_Award.Entities.Award> GetAll();
        void DeleteById(Guid id);
        void GetByTitle(string title);
    }
}
