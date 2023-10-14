using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;

namespace HMS_Web_APIs.Features.Admin.Query
{
    public class GetAllDoctorListQuery : IRequest<ResponseForGetAllDoctorList<GetAllDoctorRequestDto>>
    {
        public class GetAllDoctorListQueryHandler : IRequestHandler<GetAllDoctorListQuery, ResponseForGetAllDoctorList<GetAllDoctorRequestDto>>
        {
            private readonly sdirectdbContext _dbContext;
            public GetAllDoctorListQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForGetAllDoctorList<GetAllDoctorRequestDto>> Handle(GetAllDoctorListQuery request, CancellationToken cancellationToken)
            {
                ResponseForGetAllDoctorList<GetAllDoctorRequestDto> res = new ResponseForGetAllDoctorList<GetAllDoctorRequestDto>();

                var data = (from doc in _dbContext.HmsDoctorsTables
                           where doc.IsActive == true && doc.IsDeleted == false
                           select new GetAllDoctorRequestDto()
                           {
                               DoctorId = doc.DoctorId,
                               DoctorName = doc.DoctorName,
                               DoctorDob =  doc.DoctorDob,
                               DoctorPhone = doc.DoctorPhone,
                               DoctorEmail = doc.DoctorEmail, 
                               DoctorPassword = doc.DoctorPassword,
                               Gender = doc.Gender,
                               IsActive = doc.IsActive,
                               IsDeleted = doc.IsDeleted,
                               CreatedBy = doc.CreatedBy,
                               CreatedOn =  doc.CreatedOn
                           }).ToList();

                res.DoctorsData = data;
                res.StatusCode = 200;
                res.Message = "All Data Fetched Successfully";

                return res;
            }
        }
    }
}
