using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models.DTOs
{
    public class DeviceDTO
    {

        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

        public int TechnicianId { get; set; }

        public string Condition { get; set; } = string.Empty;
    }
}
