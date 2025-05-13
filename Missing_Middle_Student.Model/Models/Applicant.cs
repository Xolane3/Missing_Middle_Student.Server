using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models
{
    public class Applicant
    {
        public int Id { get; set; }

        // [Required]
        // [StringLength(9,ErrorMessage = "invalid length")]
        // [RegularExpression(@"\d{9}")]
        //  [ForeignKey("Student")]
        public string Student_No { get; set; } = string.Empty;

        //[Required]
        public string Password { get; set; } = string.Empty;

        // [Required]
        public string Email { get; set; } = string.Empty;

        [ForeignKey("Admin")]
        public string staffNumbeer { get; set; } = string.Empty;

        [ForeignKey("Device")]
        public int DeviceId { get; set; } 

        [Phone]
        public string Contact { get; set; } = string.Empty;


        public double Income { get; set; }
        public string Reccomendation { get; set; } = string.Empty;
        public byte[]? SupportingDoc { get; set; }

        //[Required]
        public byte[]? Accademic_record { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ApplicationDate { get; set; }

        public bool ApplicationStatus { get; set; } = false;

    }
}