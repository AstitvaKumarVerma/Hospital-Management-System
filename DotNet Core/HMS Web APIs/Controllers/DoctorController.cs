using HMS_Web_APIs.Features.Admin.Query;
using HMS_Web_APIs.Features.Patient.Command;
using HMS_Web_APIs.Features.Providers.Command;
using HMS_Web_APIs.Features.Providers.NewFolder;
using HMS_Web_APIs.Features.Providers.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HMS_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IMediator _Mediator;
        protected IMediator Mediator => _Mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("GetAllDoctorsData")]
        [Authorize(Roles = "Admin, Patient, Provider")]
        public async Task<IActionResult> GetAllDoctorsData()
        {
            return Ok(await Mediator.Send(new GetAllDoctorListQuery { }));
        }

        [HttpGet]
        [Route("GetDoctorDataById")]
        [Authorize(Roles = "Admin, Patient, Provider")]
        public async Task<IActionResult> GetDoctorDataById(int doctorId)
        {
            return Ok(await Mediator.Send(new GetDoctorByIdQuery { Id = doctorId }));
        }

        [HttpGet]
        [Route("GetAllAppointmentsByDoctorId")]
        [Authorize(Roles = "Admin, Provider")]
        public async Task<IActionResult> GetAllAppointmentsByDoctorId(int doctorId)
        {
            return Ok(await Mediator.Send(new GetAllAppointmentsByDoctorIdQuery { Id = doctorId }));
        }

        [HttpGet]
        [Route("GetAllAppointmentsByDoctorIdAndDate")]
        [Authorize(Roles = "Admin, Provider")]
        public async Task<IActionResult> GetAllAppointmentsByDoctorIdAndDate(int doctorId, DateTime selectedDate)
        {
            return Ok(await Mediator.Send(new GetAllAppointmentsByDoctorIdAndDateQuery { Id = doctorId, Selectdate = selectedDate }));
        }

        [HttpPost]
        [Route("AddDoctor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDoctor(AddDoctorCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPost]
        [Route("PopulateDoctorAvailability")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> PopulateDoctorAvailability(PopulateDoctorAvailabilityCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPut]
        [Route("UpdateDoctor")]
        [Authorize(Roles = "Admin, Provider")]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpDelete]
        [Route("DeleteDoctor")]
        [Authorize(Roles = "Admin, Provider")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
            return Ok(await Mediator.Send(new DeleteDoctorByIdCommand { Id = doctorId }));
        }
    }
}
