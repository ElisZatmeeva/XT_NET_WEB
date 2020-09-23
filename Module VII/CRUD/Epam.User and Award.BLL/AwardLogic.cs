using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.User_and_Award.DAL.Interfaces;
using Epam.Users_and_Award.Entities;
using Users_and_Awards.BLL.Interfaces;


namespace Epam.User_and_Award.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {

            _awardDao = awardDao;

        }
        public void Add(string title)
        {
            _awardDao.Add(title);
        }

        public void Update(int id, string title)
        {
            _awardDao.Update(id, title);
        }

        public Award GetAwardById(int id)
        {
           return _awardDao.GetAwardById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public void DeleteById(int id)
        {
            _awardDao.DeleteById(id);

        }
    }
}
