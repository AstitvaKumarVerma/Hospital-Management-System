using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using HMS_Web_APIs.Models.ResponseModel;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HMS_Web_APIs.Features.Login.Command
{
    public class LoginModelCommand : LoginModel, IRequest<ResponseForAuthentication>
    {
        public class LoginModelCommandHandler : IRequestHandler<LoginModelCommand, ResponseForAuthentication>
        {
            private IConfiguration _config;
            public readonly sdirectdbContext _dbContext;
            public LoginModelCommandHandler(IConfiguration config, sdirectdbContext dbContext)
            {
                _config = config;
                _dbContext = dbContext;
            }

            private string GenerateJSONWebToken(LoginModel userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


                var userRole = (from map in _dbContext.HmsUserRoleMappingTables
                                join roleMaster in _dbContext.HmsRolesTables on map.RoleId equals roleMaster.RoleId
                                join use in _dbContext.HmsLoginTables on map.UserId equals use.UserId
                                where use.UserEmail == userInfo.Email
                                select roleMaster.Role
                   ).FirstOrDefault();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userInfo.Email),
                    new Claim(ClaimTypes.Role, userRole)
                };

                // Check the user's role and add the corresponding ID claim
                if (userRole == "Patient")
                {
                    var patientId = _dbContext.HmsLoginTables
                        .Where(u => u.UserEmail == userInfo.Email)
                        .Select(u => u.PatientIdInPatientTable)
                        .FirstOrDefault();

                    if (patientId.HasValue)
                    {
                        claims.Add(new Claim("PatientId", patientId.Value.ToString()));
                    }
                }
                else if (userRole == "Provider")
                {
                    var doctorId = _dbContext.HmsLoginTables
                        .Where(u => u.UserEmail == userInfo.Email)
                        .Select(u => u.DoctorIdInDoctorTable)
                        .FirstOrDefault();

                    if (doctorId.HasValue)
                    {
                        claims.Add(new Claim("DoctorId", doctorId.Value.ToString()));
                    }
                }
                else if (userRole == "Admin")
                {
                    var userId = _dbContext.HmsLoginTables
                        .Where(u => u.UserEmail == userInfo.Email)
                        .Select(u => u.UserId)
                        .FirstOrDefault();

                    if (userId > 0)
                    {
                        claims.Add(new Claim("AdminId", userId.ToString()));
                    }
                }

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Audience"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            public async Task<ResponseForAuthentication> Handle(LoginModelCommand request, CancellationToken cancellationToken)
            {

                ResponseForAuthentication res = new ResponseForAuthentication();
                var Obj = _dbContext.HmsLoginTables.Where(i => i.UserEmail == request.Email && i.UserPassword == request.Password).FirstOrDefault();

                if (Obj != null)
                {
                    res.Message = "Valid User";
                    res.StatusCode = 200;
                    res.Token = GenerateJSONWebToken(request);
                    return res;
                }
                else
                {
                    res.Message = "User Not Exist";
                    res.StatusCode = 500;
                    res.Token = null;
                    return res;
                }

            }
        }
    }
}
