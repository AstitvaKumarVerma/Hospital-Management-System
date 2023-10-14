using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;

namespace HMS_Web_APIs.Features.Patient.Command
{
    public class SlotBookingCommand : BookSlotRequestDto, IRequest<Response>
    {
        public class SlotBookingCommandHandler : IRequestHandler<SlotBookingCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            
            public SlotBookingCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Response> Handle(SlotBookingCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();

                try 
                {
                    var data = _dbContext.HmsProviderAvailabilityTables.Where(l => l.Id == request.AvailabilityId).FirstOrDefault();

                    if (data != null)
                    {
                        data.Id = request.AvailabilityId;
                        data.IsBooked = true;
                        data.BookedBy = request.BookedBy;

                        _dbContext.SaveChanges();
                        res.StatusCode = 200;
                        res.Message = "Slot Booked Successfully.";

                        return res;
                    }
                    else
                    {
                        res.StatusCode = 404;
                        res.Message = "Slot Not Booked";
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
