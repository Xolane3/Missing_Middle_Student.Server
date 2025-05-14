using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace Missing_Middle_Student.Model
{
    public class StudentModule
    {
        public int StudentNum { get; set; }
        [ForeignKey("StudentNum")]
        public Student Student { get; set; }

        public string ModuleCode { get; set; }
        [ForeignKey("ModuleCode")]
        public Module Module { get; set; }

        public int Year { get; set; } // Optional: for tracking year enrolled
        public string Semester { get; set; } // Optional: "First", "Second"

        // ✅ New field for the grade/mark the student got
        public double Mark { get; set; }
    }
}

