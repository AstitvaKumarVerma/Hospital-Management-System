using MediatR;
using Twilio.Types;
using Twilio;
using HMS_Web_APIs.Models.ResponseModel;
using Twilio.Rest.Api.V2010.Account;
using HMS_Web_APIs.Models;
using Microsoft.EntityFrameworkCore;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Services;

namespace HMS_Web_APIs.Features.Patient.Command
{
    public class SendSMSByIdCommand : AppointmentBookSmsRequestModel, IRequest<Response>
    {
        public class SendSMSByIdCommandHandler : IRequestHandler<SendSMSByIdCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            private readonly TwilioService _twilioService;
            public SendSMSByIdCommandHandler(sdirectdbContext dbContext, TwilioService twilioService)
            {
                _dbContext = dbContext;
                _twilioService = twilioService;
            }
            public async Task<Response> Handle(SendSMSByIdCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();
                try
                {
                    var details = (from log in _dbContext.HmsLoginTables
                                   join ava in _dbContext.HmsProviderAvailabilityTables on log.PatientIdInPatientTable equals ava.BookedBy
                                   join doc in _dbContext.HmsDoctorsTables on ava.ProviderId equals doc.DoctorId
                                   where log.PatientIdInPatientTable == request.UserId && ava.Id == request.SlotAvailabilityId
                                   select new AppointmentBookSmsRequestModel()
                                   {
                                       ToPhoneNumber = "+91" + log.UserPhone,
                                       Message = $"Hii {log.UserName}, Your Appointmnet has been booked with {doc.DoctorName} on {ava.DateAvailable.ToString("dd-MM-yyyy")} at {ava.TimeSlots}. Please be available On Time."
                                   }).FirstOrDefault();

                    if (details != null)
                    {
                        // Call SendSms method with the details
                        _twilioService.SendSms(details.ToPhoneNumber, details.Message);

                        res.StatusCode = 200;
                        res.Message = "Message Has been sent successfully to the patient.";
                        return res;
                    }
                    else
                    {
                        res.StatusCode = 205;
                        res.Message = "Message Has not been sent to the patient.";
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    res.StatusCode = 500;
                    res.Message = ex.Message;

                    return res;
                }
            }
        }
    }
}
