using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models;
using MediatR;

namespace HMS_Web_APIs.Features.Admin.Query
{
    public class GetDoctorByIdQuery : IRequest<GetAllDoctorRequestDto>
    {
        public int Id { get; set; }
        public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, GetAllDoctorRequestDto>
        {
            private readonly sdirectdbContext _dbContext;
            public GetDoctorByIdQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<GetAllDoctorRequestDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
            {
                var data = (from doc in _dbContext.HmsDoctorsTables
                            where doc.DoctorId == request.Id
                            select new GetAllDoctorRequestDto()
                            {
                                DoctorId = doc.DoctorId,
                                DoctorName = doc.DoctorName,
                                DoctorDob = doc.DoctorDob,
                                DoctorPhone = doc.DoctorPhone,
                                DoctorEmail = doc.DoctorEmail,
                                DoctorPassword = doc.DoctorPassword,
                                Gender = doc.Gender,
                                IsActive = doc.IsActive,
                                IsDeleted = doc.IsDeleted,
                                CreatedBy = doc.CreatedBy,
                                CreatedOn = doc.CreatedOn
                            }).FirstOrDefault();

                return data;
            }
        }
    }
}
