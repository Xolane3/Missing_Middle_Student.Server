using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missing_Middle_Student.Model.Models;

namespace Missing_Middle_Student.Services.StaffService
{
    public interface IApplicantService
    {
        Task AddApplicantAsync(Applicant applicant);
        Task<Applicant> FindApplicationAsync(int id);
    }
}