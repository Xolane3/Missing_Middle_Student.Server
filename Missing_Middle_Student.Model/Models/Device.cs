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
        public string DeviceContract { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; }
        public string Condition { get; set; }
        public DateOnly AllowcationDate { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
