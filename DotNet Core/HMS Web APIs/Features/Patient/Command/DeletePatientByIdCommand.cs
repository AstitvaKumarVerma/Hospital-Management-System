using HMS_Web_APIs.Models.ResponseModel;
using HMS_Web_APIs.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HMS_Web_APIs.Features.Patient.Command
{
    public class DeletePatientByIdCommand : IRequest<Response>
    {
        public int Id { get; set; }

        public class DeletePatientByIdCommandHandler : IRequestHandler<DeletePatientByIdCommand, Response>
        {
            private readonly sdirectdbContext _dbContext;
            public DeletePatientByIdCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Response> Handle(DeletePatientByIdCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();

                try
                {
                    var data = _dbContext.HmsPatientsTables.FirstOrDefault(x => x.PatientId == request.Id);
                    if (data != null)
                    {
                        //Connection string ---
                        var builder = WebApplication.CreateBuilder();
                        var conString = builder.Configuration.GetConnectionString("AppConn");
                        SqlConnection con = new SqlConnection(conString);
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        // Calling SP

                        SqlCommand cmd = new SqlCommand("SP_HmsPatientsTable_DeletePatientDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@PatientId", SqlDbType.Int).Value = request.Id;

                        int iReturn = cmd.ExecuteNonQuery();
                        con.Close();
                        if (iReturn > 0)
                        {
                            res.StatusCode = 200;
                            res.Message = "Patient Delete Succesfully";
                            return res;
                        }
                        else
                        {
                            res.StatusCode = 203;
                            res.Message = "Patient Not Delete";
                            return res;
                        }
                    }
                    else
                    {
                        res.StatusCode = 404;
                        res.Message = "Patient ID Does not Exists";
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
