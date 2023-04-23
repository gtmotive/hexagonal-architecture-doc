using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Identity.Models;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="userManager">UserManager.</param>
        /// <param name="jwtSettings">JwtSettings.</param>
        /// <param name="unitOfWork">unitOfWork.</param>
        public AuthController(IMapper mapper, UserManager<User> userManager, IOptionsSnapshot<JwtSettings> jwtSettings, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            if (jwtSettings != null)
            {
                _jwtSettings = jwtSettings.Value;
            }
        }

        /// <summary>
        /// SignUp.
        /// </summary>
        /// <param name="userSignUpResource">UserSignUpResource.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
        {
            if (userSignUpResource == null)
            {
                return BadRequest();
            }

            var user = _mapper.Map<UserSignUpResource, User>(userSignUpResource);
            var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);

            return userCreateResult.Succeeded ? Ok() : Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
        {
            if (userLoginResource == null)
            {
                return BadRequest();
            }

            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Email);
            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var vehiclesInfo = await _unitOfWork.ReservationRepository.GetReservationsByUserIdAsync(user.Id);

                return Ok(AuthHelper.GenerateJwt(user, roles, vehiclesInfo.Select(c => c.Vehicle.RegistrationNumber).ToList(), _jwtSettings));
            }
            else
            {
                return BadRequest("Email or password incorrect.");
            }
        }
    }
}
