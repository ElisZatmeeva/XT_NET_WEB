using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users_and_Award.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }

        /*public override string ToString()
        {
            return string.Format("{0}, {1}", Id, Title);
        }*/
    }
}
