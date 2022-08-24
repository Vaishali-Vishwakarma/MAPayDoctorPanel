using APICRUDStoredProc.Interface;
using APICRUDStoredProc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICRUDStoredProc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IDoctor _IDoctor;

        public RegistrationController(IDoctor iDoctor)
        {
            _IDoctor = iDoctor;
        }

        [HttpGet]
        public async Task<List<Doctor>> Get()
        {
            return await Task.FromResult(_IDoctor.GetDoctorDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Doctor doctor = _IDoctor.GetDoctorData(id);
            if (doctor != null)
            {
                return Ok(doctor);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Doctor doctor)
        {
            _IDoctor.AddDoctor(doctor);
        }

        [HttpPut]
        public IActionResult Put(Doctor doctor)
        {
            _IDoctor.UpdateDoctorDetails(doctor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IDoctor.DeleteDoctor(id);
            return Ok();
        }
    }
}
