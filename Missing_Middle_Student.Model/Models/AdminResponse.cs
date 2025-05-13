using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models
{
    public struct AdminResponse
    {
        public Dictionary<string, int> Device_Info { get; set; }
        public Dictionary<string, int> Applicants_Data { get; set; }
        public Dictionary<string, int> Applicants_Montly_Data { get; set; }


    }
}
