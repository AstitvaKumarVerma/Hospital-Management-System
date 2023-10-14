using HMS_Web_APIs.Features.Patient.Command;
using HMS_Web_APIs.Models.ResponseModel;
using HMS_Web_APIs.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HMS_Web_APIs.Features.Providers.NewFolder
{
    public class DeleteDoctorByIdCommand : IRequest<Response>
    {
        public int Id { get; set; }

        public class DeleteDoctorByIdCommandHandler : IRequestHandler<DeleteDoctorByIdCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            public DeleteDoctorByIdCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Response> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();

                try
                {
                    var data = _dbContext.HmsDoctorsTables.FirstOrDefault(x => x.DoctorId == request.Id);
                    if (data != null)
                    {
                        //Connection string ---
                        var builder = WebApplication.CreateBuilder();
                        var conString = builder.Configuration.GetConnectionString("AppConn");
                        SqlConnection con = new SqlConnection(conString);
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        // Calling SP

                        SqlCommand cmd = new SqlCommand("SP_HmsDoctorsTable_DeleteDoctorDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@DoctorId", SqlDbType.Int).Value = request.Id;

                        int iReturn = cmd.ExecuteNonQuery();
                        con.Close();
                        if (iReturn > 0)
                        {
                            res.StatusCode = 200;
                            res.Message = "Doctor Delete Succesfully";
                            return res;
                        }
                        else
                        {
                            res.StatusCode = 203;
                            res.Message = "Doctor Not Delete";
                            return res;
                        }
                    }
                    else
                    {
                        res.StatusCode = 404;
                        res.Message = "Doctor ID Does not Exists";
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
