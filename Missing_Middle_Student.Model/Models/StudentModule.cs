using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Missing_Middle_Student.Model
{
    public class StudentModule
    {
        [Required]
        public int StudentNum { get; set; }

        [ForeignKey("StudentNum")]
        public Student Student { get; set; }

        

        public string ModuleCode { get; set; }
        [ForeignKey("ModuleCode")]
        public Module Module { get; set; }

        public int Mark { get; set; }  // ✅ Correct place for mark
        public int Year { get; set; }
        public string Semester { get; set; }
    }
}
