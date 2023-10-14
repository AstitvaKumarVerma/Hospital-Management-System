using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;

namespace HMS_Web_APIs.Features.Patient.Query
{
    public class GetAllAppoinmentsByPatientIdQuery : IRequest<ResponseForGetAllAppoinmentsOfPatient<GetAllAppoinmentsOfPatientRequestDto>>
    {
        public int Id { get; set; }
        public class GetAllAppoinmentsByPatientIdQueryHandler : IRequestHandler<GetAllAppoinmentsByPatientIdQuery, ResponseForGetAllAppoinmentsOfPatient<GetAllAppoinmentsOfPatientRequestDto>>
        {
            private readonly sdirectdbContext _dbContext;
            public GetAllAppoinmentsByPatientIdQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForGetAllAppoinmentsOfPatient<GetAllAppoinmentsOfPatientRequestDto>> Handle(GetAllAppoinmentsByPatientIdQuery request, CancellationToken cancellationToken)
            {
                ResponseForGetAllAppoinmentsOfPatient<GetAllAppoinmentsOfPatientRequestDto> res = new ResponseForGetAllAppoinmentsOfPatient<GetAllAppoinmentsOfPatientRequestDto>();

                var data = ( from pat in _dbContext.HmsPatientsTables
                             join ava in _dbContext.HmsProviderAvailabilityTables on pat.PatientId equals ava.BookedBy
                             join doc in _dbContext.HmsDoctorsTables on ava.ProviderId equals doc.DoctorId
                             orderby ava.DateAvailable descending
                             where pat.PatientId == request.Id
                             select new GetAllAppoinmentsOfPatientRequestDto()
                             {
                                 PatientId = pat.PatientId,
                                 PatientName = pat.PatientName,
                                 DoctorId = doc.DoctorId,
                                 DoctorName = doc.DoctorName,
                                 AppoinmentDate = ava.DateAvailable,
                                 AppoinmentTime = ava.TimeSlots
                             }).ToList();

                res.PatientAppoinments = data;
                res.StatusCode = 200;
                res.Message = "All Appoinments Fetched";
                return res;
            }
        }
    }
}
