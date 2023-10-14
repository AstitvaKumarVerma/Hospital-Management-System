using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;

namespace HMS_Web_APIs.Features.Patient.Query
{
    public class GetAvailableSlotQuery : IRequest<ResponseForAvailableSlotList<GetSlotRequestDto>>
    {
        public int AppointFor { get; set; }
        public DateTime SlotDate { get; set; }
        public class GetAvailableSlotQueryHandler : IRequestHandler<GetAvailableSlotQuery, ResponseForAvailableSlotList<GetSlotRequestDto>>
        {
            private readonly sdirectdbContext _dbContext;
            public GetAvailableSlotQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForAvailableSlotList<GetSlotRequestDto>> Handle(GetAvailableSlotQuery request, CancellationToken cancellationToken)
            {
                ResponseForAvailableSlotList<GetSlotRequestDto> res = new ResponseForAvailableSlotList<GetSlotRequestDto>();

                var data = (from ava in _dbContext.HmsProviderAvailabilityTables
                            join doc in _dbContext.HmsDoctorsTables on ava.ProviderId equals doc.DoctorId
                            where (ava.ProviderId == request.AppointFor && ava.DateAvailable == request.SlotDate && ava.IsBooked == false)
                            select new GetSlotRequestDto()
                            {
                                DoctorId = doc.DoctorId,
                                DoctorName = doc.DoctorName,
                                AvailabilityId = ava.Id,
                                DateAvailable = ava.DateAvailable,
                                TimeSlot = ava.TimeSlots   
                            }).ToList();
                res.AvailableSlots = data;
                res.StatusCode = 200;
                res.Message = "All The Available Slots are fetched Successfully";
                return res;
            }
        }
    }
}
