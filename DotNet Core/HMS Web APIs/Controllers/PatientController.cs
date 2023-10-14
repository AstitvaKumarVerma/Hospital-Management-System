using HMS_Web_APIs.Features.Admin.Query;
using HMS_Web_APIs.Features.Patient.Command;
using HMS_Web_APIs.Features.Patient.Query;
using HMS_Web_APIs.Models.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IMediator _Mediator;
        protected IMediator Mediator => _Mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("GetAllPatientsData")]
        [Authorize(Roles = "Admin, Provider")]
        public async Task<IActionResult> GetAllPatientsData()
        {
            return Ok(await Mediator.Send(new GetAllPatientListQuery { }));
        }

        [HttpGet]
        [Route("GetPatientDataById")]
        [Authorize(Roles = "Admin, Provider, Patient")]
        public async Task<IActionResult> GetPatientDataById(int patientId)
        {
            return Ok(await Mediator.Send(new GetPatientByIdQuery { Id = patientId }));
        }


        [HttpGet]
        [Route("GetPatientProfileDataById")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetPatientProfileDataById(int patientId)
        {
            return Ok(await Mediator.Send(new GetPatientProfileDataByIdQuery { Id = patientId }));
        }

        [HttpGet]
        [Route("GetAllAppoinmentsByPatientId")]
        //[Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetAllAppoinmentsByPatientId(int patientId)
        {
            return Ok(await Mediator.Send(new GetAllAppoinmentsByPatientIdQuery { Id = patientId }));
        }

        [HttpPost]
        [Route("SendSmsForAppointmentByPatientId")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> SendSmsForAppointmentByPatientId(SendSMSByIdCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPost]
        [Route("AddPatient")]
        //[Authorize(Roles = "Patient")]

        public async Task<IActionResult> AddPatient(AddPatientCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpGet]
        [Route("GetAvailableSlot")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetAvailableSlotByDoctorId (int doctorId, DateTime date)
        {
            return Ok(await Mediator.Send(new GetAvailableSlotQuery { AppointFor = doctorId, SlotDate = date }));
        }

        [HttpPut]
        [Route("SlotBooking")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> SlotBooking(SlotBookingCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPut]
        [Route("UpdatePatient")]
        [Authorize(Roles = "Admin, Patient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpDelete]
        [Route("DeletePatient")]
        [Authorize(Roles = "Admin, Patient")]

        public async Task<IActionResult> DeletePatient(int patientId)
        {
            return Ok(await Mediator.Send(new DeletePatientByIdCommand { Id = patientId }));
        }
    }
}
