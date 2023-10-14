using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using HMS_Web_APIs.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HMS_Web_APIs.Features.Patient.Command
{
    public class UpdatePatientCommand : UpdatePatientRequestDto, IRequest<Response>
    {
        public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            public UpdatePatientCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Response> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();


                try
                {
                    var data = _dbContext.HmsPatientsTables.FirstOrDefault(x => x.PatientId == request.PatientId);
                    if (data != null)
                    {
                        //Connection string ---
                        var builder = WebApplication.CreateBuilder();
                        var conString = builder.Configuration.GetConnectionString("AppConn");
                        SqlConnection con = new SqlConnection(conString);
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        // Calling SP

                        SqlCommand cmd = new SqlCommand("SP_HmsPatientsTable_UpdatePatientDetails ", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@PatientId", SqlDbType.Int).Value = request.PatientId;
                        cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = request.PatientName;
                        cmd.Parameters.Add("@PatientDOB", SqlDbType.Date).Value = request.PatientDob;
                        cmd.Parameters.Add("@PatientPhone", SqlDbType.VarChar).Value = request.PatientPhone;
                        cmd.Parameters.Add("@PatientEmail", SqlDbType.VarChar).Value = request.PatientEmail;
                        cmd.Parameters.Add("@PatientPassword", SqlDbType.VarChar).Value = request.PatientPassword;
                        cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = request.Gender;
                        cmd.Parameters.Add("@FatherName", SqlDbType.VarChar).Value = request.FatherName;
                        cmd.Parameters.Add("@MaritalStatus", SqlDbType.VarChar).Value = request.MaritalStatus;
                        cmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar).Value = request.BloodGroup;
                        cmd.Parameters.Add("@Symptoms", SqlDbType.VarChar).Value = request.Symptoms;
                        cmd.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = request.Diagnosis;

                        int iReturn = cmd.ExecuteNonQuery();
                        con.Close();
                        if (iReturn > 0)
                        {
                            res.StatusCode = 200;
                            res.Message = "Patient Update Succesfully";
                            return res;
                        }
                        else
                        {
                            res.StatusCode = 203;
                            res.Message = "Patient Not Update";
                            return res;
                        }
                    }
                    else
                    {
                        res.StatusCode = 404;
                        res.Message = "Patient Does not Exists";
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
