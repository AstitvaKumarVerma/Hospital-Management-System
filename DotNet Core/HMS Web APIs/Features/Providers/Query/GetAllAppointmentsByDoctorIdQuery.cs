using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace HMS_Web_APIs.Features.Providers.Query
{
    public class GetAllAppointmentsByDoctorIdQuery : IRequest<ResponseForDoctorAppoinments<GetAllDoctorAppoinments>>
    {
        public int Id { get; set; }
        public class GetAllAppointmentsByDoctorIdQueryHandler : IRequestHandler<GetAllAppointmentsByDoctorIdQuery, ResponseForDoctorAppoinments<GetAllDoctorAppoinments>>
        {
            private readonly sdirectdbContext _dbContext;
            public GetAllAppointmentsByDoctorIdQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForDoctorAppoinments<GetAllDoctorAppoinments>> Handle(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
            {
                ResponseForDoctorAppoinments<GetAllDoctorAppoinments> res = new ResponseForDoctorAppoinments<GetAllDoctorAppoinments>();

                try
                {

                    var objData = (from u in _dbContext.HmsLoginTables
                                   join a in _dbContext.HmsProviderAvailabilityTables on u.PatientIdInPatientTable equals a.BookedBy
                                   where a.IsBooked == true && a.ProviderId == request.Id
                                   select new GetAllDoctorAppoinments
                                   {
                                       title = u.UserName,
                                       //date =  a.DateAvailable.ToString("dd-MM-yyyy"),
                                       date= DateTime.ParseExact(a.DateAvailable.ToString(), "MMM dd yyyy hh:mmtt", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                                       start = a.TimeSlots
                                   }
                                   ).ToList();

                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.DoctorBookedSlots = objData;

                    return res;
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
