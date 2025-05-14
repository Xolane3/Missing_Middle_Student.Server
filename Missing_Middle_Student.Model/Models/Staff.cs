using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string Initails { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
