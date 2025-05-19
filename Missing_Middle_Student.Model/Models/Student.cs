using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Missing_Middle_Student.Model
{
    [Index(nameof(StudentNum), IsUnique = true)]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public int StudentNum { get; set; }

        public string Initials { get; set; }
        public string CourseName { get; set; }
        public string Faculty { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Nationality { get; set; }
        public string NsfasStatus { get; set; }
        public int YearOfStudy { get; set; }
        public string Ethnicity { get; set; }

        public double? AverageMark { get; set; }

        public ICollection<StudentModule> StudentModules { get; set; }
    }
}
