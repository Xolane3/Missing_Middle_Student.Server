using System.ComponentModel.DataAnnotations;



namespace Missing_Middle_Student.Model
{
    public class Module
    {
        [Key]
        public string ModuleCode { get; set; }

        public string ModuleName { get; set; }


        public int Credit { get; set; }
        public string Prerequisite { get; set; }

        public ICollection<StudentModule> StudentModules { get; set; }
    }
}
