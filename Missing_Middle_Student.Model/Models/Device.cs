using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models
{
    public class Device
    {
       public int DeviceId { get; set; }
        public string DeviceContract { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int StaffId { get; set; } 
        public DateOnly AllowcationDate { get; set; }

    }
}
