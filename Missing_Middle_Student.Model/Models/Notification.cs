using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateOnly CreatedAt { get; set; }
        public bool Seen {  get; set; }


    }
}
