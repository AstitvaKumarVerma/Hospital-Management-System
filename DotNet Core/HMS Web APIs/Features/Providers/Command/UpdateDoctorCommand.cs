using HMS_Web_APIs.Features.Patient.Command;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using HMS_Web_APIs.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HMS_Web_APIs.Features.Providers.NewFolder
{
    public class UpdateDoctorCommand : UpdateDoctorRequestDto, IRequest<Response>
    {
        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            public UpdateDoctorCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Response> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();

                try
                {
                    var data = _dbContext.HmsDoctorsTables.FirstOrDefault(x => x.DoctorId == request.DoctorId);
                    if (data != null)
                    {
                        //Connection string ---
                        var builder = WebApplication.CreateBuilder();
                        var conString = builder.Configuration.GetConnectionString("AppConn");
                        SqlConnection con = new SqlConnection(conString);
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        // Calling SP

                        SqlCommand cmd = new SqlCommand("SP_HmsDoctorsTable_UpdateDoctorDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@DoctorId", SqlDbType.Int).Value = request.DoctorId;
                        cmd.Parameters.Add("@DoctorName", SqlDbType.VarChar).Value = request.DoctorName;
                        cmd.Parameters.Add("@DoctorDOB", SqlDbType.Date).Value = request.DoctorDob;
                        cmd.Parameters.Add("@DoctorPhone", SqlDbType.VarChar).Value = request.DoctorPhone;
                        cmd.Parameters.Add("@DoctorEmail", SqlDbType.VarChar).Value = request.DoctorEmail;
                        cmd.Parameters.Add("@DoctorPassword", SqlDbType.VarChar).Value = request.DoctorPassword;
                        cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = request.Gender;

                        int iReturn = cmd.ExecuteNonQuery();
                        con.Close();
                        if (iReturn > 0)
                        {
                            res.StatusCode = 200;
                            res.Message = "Doctor Updated Succesfully";
                            return res;
                        }
                        else
                        {
                            res.StatusCode = 203;
                            res.Message = "Doctor is Not Updated";
                            return res;
                        }
                    }
                    else
                    {
                        res.StatusCode = 404;
                        res.Message = "Doctor Does not Exists";
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
