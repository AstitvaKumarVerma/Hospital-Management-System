using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;
using System.Security.Cryptography;

namespace HMS_Web_APIs.Features.Admin.Query
{
    public class GetAllPatientListQuery: IRequest<ResponseForGetAllPatientList<GetAllPatientRequestDto>>
    {
        public class GetAllPatientListQueryHandler : IRequestHandler<GetAllPatientListQuery, ResponseForGetAllPatientList<GetAllPatientRequestDto>>
        {
            private readonly sdirectdbContext _dbContext;

            public GetAllPatientListQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForGetAllPatientList<GetAllPatientRequestDto>> Handle(GetAllPatientListQuery request, CancellationToken cancellationToken)
            {
                ResponseForGetAllPatientList<GetAllPatientRequestDto> res = new ResponseForGetAllPatientList<GetAllPatientRequestDto>();

                var obj = (from pat in _dbContext.HmsPatientsTables
                           join ava in _dbContext.HmsProviderAvailabilityTables on pat.PatientId equals ava.BookedBy
                           join doc in _dbContext.HmsDoctorsTables on ava.ProviderId equals doc.DoctorId
                           where pat.IsActive == true && pat.IsDeleted == false
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
                           }).ToList();

                res.PatientsData = obj;
                res.StatusCode = 200;
                res.Message = "All Data Fetched Successfully";
                return res;
            }
        }
    }
}
