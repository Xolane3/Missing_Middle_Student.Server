
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missing_Middle_Student.Model;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Services.StaffService;

namespace Missing_Middle_Student.Services.StaffService
{
    public class ApplicantService : IApplicantService
    {

        readonly AppDBContext _context;
        public ApplicantService(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddApplicantAsync(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
        }
        public async Task<Applicant> FindApplicationAsync(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);

            return applicant;
        }
        
    }
}
