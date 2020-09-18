using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users_and_Award.Entities;
using Epam.Award.BLL.Interface;
using Epam.Award.DAL.Interfaces;


namespace Epam.Award.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }
        int IAwardLogic.Add(Users_and_Award.Entities.Award award)
        {
            return _awardDao.Add(award);
        }

        void IAwardLogic.DeleteById(Guid id)
        {
            _awardDao.DeleteById(id);
        }

        IEnumerable<Users_and_Award.Entities.Award> IAwardLogic.GetAll()
        {
            return _awardDao.GetAll();
        }

        void IAwardLogic.GetByTitle(string title)
        {
            _awardDao.GetByTitle(title);
        }
    }
}
