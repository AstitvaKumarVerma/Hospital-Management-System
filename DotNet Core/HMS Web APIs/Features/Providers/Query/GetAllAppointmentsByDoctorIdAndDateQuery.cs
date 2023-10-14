using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;

namespace HMS_Web_APIs.Features.Providers.Query
{
    public class GetAllAppointmentsByDoctorIdAndDateQuery : IRequest<ResponseForDoctorAppoinments<GetAllDoctorAppoinments>>
    {
        public int Id { get; set; }
        public DateTime Selectdate { get; set; }
        public class GetAllAppointmentsByDoctorIdAndDateQueryHandler : IRequestHandler<GetAllAppointmentsByDoctorIdAndDateQuery, ResponseForDoctorAppoinments<GetAllDoctorAppoinments>>
        {
            private readonly sdirectdbContext _dbContext;
            public GetAllAppointmentsByDoctorIdAndDateQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForDoctorAppoinments<GetAllDoctorAppoinments>> Handle(GetAllAppointmentsByDoctorIdAndDateQuery request, CancellationToken cancellationToken)
            {
                ResponseForDoctorAppoinments<GetAllDoctorAppoinments> res = new ResponseForDoctorAppoinments<GetAllDoctorAppoinments>();

                try
                {

                    var objData = (from u in _dbContext.HmsLoginTables
                                   join a in _dbContext.HmsProviderAvailabilityTables on u.PatientIdInPatientTable equals a.BookedBy
                                   where a.IsBooked == true && a.ProviderId == request.Id && a.DateAvailable == request.Selectdate
                                   select new GetAllDoctorAppoinments
                                   {
                                       title = char.ToUpper(u.UserName[0]) + u.UserName.Substring(1),
                                       date = a.DateAvailable.ToString("yyyy-MM-dd"),
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
