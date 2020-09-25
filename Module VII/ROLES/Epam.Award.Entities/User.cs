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
        public byte[] Image { get; set; }
        public string filename { get; set; }
        public string Password { get; set; }

    }
}
