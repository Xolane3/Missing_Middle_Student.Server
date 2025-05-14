using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missing_Middle_Student.Model.Models;

namespace Missing_Middle_Student.Model.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
