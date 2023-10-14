using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using MediatR;

namespace HMS_Web_APIs.Features.Admin.Query
{
    public class GetPatientByIdQuery : IRequest<GetAllPatientRequestDto>
    {
        public int Id { get; set; }
        public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetAllPatientRequestDto>
        {
            private readonly sdirectdbContext _dbContext;
            public GetPatientByIdQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<GetAllPatientRequestDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
            {
                var data = (from pat in _dbContext.HmsPatientsTables
                            join ava in _dbContext.HmsProviderAvailabilityTables on pat.PatientId equals ava.BookedBy
                            join doc in _dbContext.HmsDoctorsTables on ava.ProviderId equals doc.DoctorId
                            where pat.PatientId == request.Id 
                            select new GetAllPatientRequestDto()
                            {
                                PatientId = pat.PatientId,
                                PatientName = pat.PatientName,
                                PatientDob = pat.PatientDob,
                                PatientPhone = pat.PatientPhone,
                                PatientEmail = pat.PatientEmail,
                                PatientPassword = pat.PatientPassword,
                                Gender = pat.Gender,
                                FatherName = pat.FatherName,
                                MaritalStatus = pat.MaritalStatus,
                                BloodGroup = pat.BloodGroup,
                                Symptoms = pat.Symptoms,
                                Diagnosis = pat.Diagnosis,
                                DoctorId = ava.ProviderId,
                                DoctorName = doc.DoctorName,
                                AppointmentDate = ava.DateAvailable,
                                AppointmentTime = ava.TimeSlots,
                                IsActive = pat.IsActive,
                                IsDeleted = pat.IsDeleted,
                                CreatedBy = pat.CreatedBy,
                                CreatedOn = pat.CreatedOn,
                            }).FirstOrDefault();

                return data;
            }
        }
    }
}
