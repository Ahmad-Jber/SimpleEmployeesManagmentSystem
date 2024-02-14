/*using AutoMapper;
using EntityFrameworkTutorial.Dtos.User;
using EntityFrameworkTutorial.Entities;
using EntityFrameworkTutorial.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace EntityFrameworkTutorial.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Entities.Employee> _userManager;
        private readonly JWT _jwt;
        private Entities.Employee _employee;

        public UserService(IMapper mapper, UserManager<Entities.Employee> userManager, IOptions<JWT> jwtOptions)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwt = jwtOptions.Value;
        }

        public async Task<Authentication> RegisterAsync(RegisterDto registerDto)
        {
            if (
                !_userManager.FindByEmailAsync(registerDto.Email).Equals(null) ||
                !_userManager.FindByNameAsync(registerDto.Username).Equals(null)
            )
            {
                return new Authentication { Message = "Your username or email was exist", IsAuthenticated = false};
            }
            _employee = _mapper.Map<Entities.Employee>(registerDto);
            var result = await _userManager.CreateAsync(_employee, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                result.Errors.ToList().ForEach(error => { errors += error.Description + "\n"; });
                return new Authentication
                {
                    Message = errors,
                    IsAuthenticated = false
                };
            }

            await _userManager.AddToRoleAsync(_employee, "Employee");
            var jwtToken = await CreateJwtToken();
            return new Authentication
            {
                Email = _employee.Email,
                Username = _employee.UserName,
                IsAuthenticated = true,
                Message = "You have been registered successfully",
                Roles = new List<string> { "No Role" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                TokenExpirationTime = jwtToken.ValidTo
            };
        }

        public async Task<JwtSecurityToken> CreateJwtToken()
        {
            var userClaims = await _userManager.GetClaimsAsync(_employee);
            var roles = await _userManager.GetRolesAsync(_employee);
            var roleClaims = new List<Claim>();
            roles.ToList().ForEach(role => { roleClaims.Add(new Claim("roles", role)); });
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _employee.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, _employee.Email),
                    new Claim("uid", _employee.Id),
                }
                .Union(userClaims)
                .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.ExpireMinutes),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }
    }
}*/