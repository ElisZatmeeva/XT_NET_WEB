using Epam.Users_and_Award.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_and_Awards.BLL.Interfaces;
using System.Data.SqlClient;
using Epam.Users_and_User.Common;
using Epam.Users_and_Award.Entities;

namespace ThreeLayer
{
    class Program
    {
        static void Main(string[] args)
        {

            /*var awardLogic = DependencyResolverAward.AwardLogic;
            Console.ReadLine();*/

            var userLogic = DependencyResolverUser.UserLogic;
           /* userLogic.GetUserById(3);*/

            /*userLogic.Add("Kharkusha", (int)15, new DateTime(2005, 04, 04));*/
            /*userLogic.DeleteById(28);*/
            /*userLogic.GetAll();*/


            var awardLogic = DependencyResolverAward.AwardLogic;
            /*awardLogic.Add("silver");
            awardLogic.GetAll();*/
            Console.ReadLine();

        }
    }
}
