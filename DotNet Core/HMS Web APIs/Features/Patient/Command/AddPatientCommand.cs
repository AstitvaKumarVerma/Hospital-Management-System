using HMS_Web_APIs.Models.ResponseModel;
using HMS_Web_APIs.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using HMS_Web_APIs.Models.RequestModel;

namespace HMS_Web_APIs.Features.Patient.Command
{
    public class AddPatientCommand : AddPatientRequestDto, IRequest<Response>
    {
        public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            public AddPatientCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Response> Handle(AddPatientCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();


                try
                {
                    var data = _dbContext.HmsPatientsTables.FirstOrDefault(x => x.PatientEmail == request.PatientEmail && x.PatientPassword == request.PatientPassword);
                    if (data != null)
                    {
                        res.StatusCode = 203;
                        res.Message = "Patient Already Exists";
                        return res;

                    }
                    else
                    {
                        //Connection string ---
                        var builder = WebApplication.CreateBuilder();
                        var conString = builder.Configuration.GetConnectionString("AppConn");
                        SqlConnection con = new SqlConnection(conString);
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        // Calling SP

                        SqlCommand cmd = new SqlCommand("SP_HmsPatientsTable_InsertPatientDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;

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

                        // Output parameter for returning the newly inserted PatientId
                        //SqlParameter outputParameter = new SqlParameter("@PatientId", SqlDbType.Int);
                        //outputParameter.Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(outputParameter);

                        // Get the newly inserted PatientId
                        //int newPatientId = Convert.ToInt32(outputParameter.Value);



                        int iReturn = cmd.ExecuteNonQuery();
                        con.Close();
                        if (iReturn > 0)
                        {
                            res.StatusCode = 200;
                            res.Message = "Patient Add Succesfully";
                            return res;
                        }
                        else
                        {
                            res.StatusCode = 400;
                            res.Message = "Patient Not Add";
                            return res;
                        }
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
