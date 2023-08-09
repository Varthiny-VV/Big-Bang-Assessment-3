using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignInAndSignUp.Interfaces;
using SignInAndSignUp.Models.DTO;
using SignInAndSignUp.Models;
using Microsoft.AspNetCore.Cors;

namespace SignInAndSignUp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _userService;
        private readonly IRepo<Users, string> _userRepo;
        private readonly IRepo<Traveller, string> _travellerRepo;
        private readonly IRepo<TravelAgent, string> _agentRepo;
        private readonly IAdminService _adminService;


        public UserController(IManageUser userService, IRepo<Users, string> userRepo,
                              IRepo<Traveller, string> travellerRepo, IRepo<TravelAgent, string> agentRepo
                             , IAdminService adminService)
        {
            _agentRepo = agentRepo;
            _userService = userService;
            _userRepo = userRepo;
            _travellerRepo = travellerRepo;
            _adminService = adminService;

        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response

        public async Task<ActionResult<UserDTO?>> RegisterTravelAgent(TravelAgentRegistrationDTO travelAgentRegistration)
        {
            try
            {
                var agent = await _userService.TravelAgentRegistration(travelAgentRegistration);
                if (agent != null)
                    return Created("Registered! :)", agent);
                return BadRequest("Unable to register");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response

        public async Task<ActionResult<UserDTO?>> RegisterTraveller(TravellerRegistrationDTO travellerRegistration)
        {
            try
            {
                var traveller = await _userService.TravellerRegistration(travellerRegistration);
                if (traveller != null)
                    return Created("Registered! :)", traveller);
                return BadRequest("Unable to register");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> Login(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.Login(userDTO);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("Unable to login");
            }
            catch (Exception)
            {
                return BadRequest("Network error...Please try later");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(TravelAgent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        public async Task<ActionResult<TravelAgent?>> UpdateAgentStatus(ApproveStatus status)
        {
            try
            {
                var agent = await _adminService.UpdateStatus(status);
                if (agent != null)
                {
                    return Ok(agent);
                }
                return BadRequest("Not updated!");
            }
            catch (Exception)
            {
                return BadRequest("Backend error!");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TravelAgent>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<TravelAgent>>> GetAllAgents()
        {
            try
            {
                var agents = await _agentRepo.GetAll();
                if (agents != null)
                {
                    return Ok(agents);
                }
                return BadRequest("No Agents available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(TravelAgent), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TravelAgent>> GetAgent(string email)
        {
            try
            {
                var agent = await _agentRepo.Get(email);
                if (agent != null)
                {
                    return Ok(agent);
                }
                return BadRequest("No agent found :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }
    }
}
