using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users_and_Award.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Id, Name, DateOfBirth, Age);
        }
    }
}
