using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Services.Studentservices;

namespace Missing_Middle_Student.API.Controllers.StudentComtroller
{
    
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicantService _appicantService;

        public ApplicationController(IApplicantService appicantService)
        {
            _appicantService = appicantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicant(Applicant applicant, IFormFile SupportingDoc, IFormFile AcademicRec)
        {
           
            if (AcademicRec != null && AcademicRec.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await AcademicRec.CopyToAsync(memoryStream);
                applicant.Accademic_record = memoryStream.ToArray(); // Assuming `AcademicRecord` is a byte[] property on Applicant
            }

            if (SupportingDoc != null && SupportingDoc.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await SupportingDoc.CopyToAsync(memoryStream);
                applicant.SupportingDoc = memoryStream.ToArray(); // Assuming `AcademicRecord` is a byte[] property on Applicant
            }

            await _appicantService.AddApplicantAsync(applicant);


            return CreatedAtAction(nameof(GetApplicant), new { id = applicant.Id }, applicant);
        }


        [HttpGet]
        public async Task<ActionResult> GetApplicant(int id)
        {
            var applicant = await _appicantService.FindApplicationAsync(id);

            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }



    }
}
