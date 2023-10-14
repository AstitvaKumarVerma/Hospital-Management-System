using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using MediatR;

namespace HMS_Web_APIs.Features.Admin.Query
{
    public class GetPatientProfileDataByIdQuery : IRequest<GetAllPatientRequestDto>
    {
        public int Id { get; set; }
        public class GetPatientProfileDataByIdQueryHandler : IRequestHandler<GetPatientProfileDataByIdQuery, GetAllPatientRequestDto>
        {
            private readonly sdirectdbContext _dbContext;
            public GetPatientProfileDataByIdQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<GetAllPatientRequestDto> Handle(GetPatientProfileDataByIdQuery request, CancellationToken cancellationToken)
            {
                var data = (from pat in _dbContext.HmsPatientsTables
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
