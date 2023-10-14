using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;

namespace HMS_Web_APIs.Features.Providers.Command
{
    public class PopulateDoctorAvailabilityCommand : DoctorAvailabilityRequestDto, IRequest<Response>
    {
        public class PopulateDoctorAvailabilityCommandHandler : IRequestHandler<PopulateDoctorAvailabilityCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            public PopulateDoctorAvailabilityCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Response> Handle(PopulateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();

                try
                {
                    //Connection string ---
                    var builder = WebApplication.CreateBuilder();
                    var conString = builder.Configuration.GetConnectionString("AppConn");
                    SqlConnection con = new SqlConnection(conString);
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    // Calling SP
                    SqlCommand cmd = new SqlCommand("SP_Populate_HmsProviderAvailability_Dynamic", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value =request.StartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = request.EndDate; 
                    cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = TimeSpan.Parse(request.StartTime); 
                    cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = TimeSpan.Parse(request.EndTime); 
                    cmd.Parameters.Add("@IntervalMinutes", SqlDbType.Int).Value = request.IntervalMinutes; 
                    cmd.Parameters.Add("@ProviderId", SqlDbType.Int).Value = request.ProviderId;

                    int iReturn = cmd.ExecuteNonQuery();
                    con.Close();
                    if (iReturn > 0)
                    {
                        res.StatusCode = 200;
                        res.Message = "Provider Availability has been Added Succesfully";
                        return res;
                    }
                    else
                    {
                        res.StatusCode = 400;
                        res.Message = "Provider Availability Not Add";
                        return res;
                    }
                }
                   
                catch(Exception ex) 
                {
                    res.StatusCode = 500;
                    res.Message = ex.Message;

                    return res;
                }
            }
        }
    }
}
