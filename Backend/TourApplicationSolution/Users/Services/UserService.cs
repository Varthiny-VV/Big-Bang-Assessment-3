using SignInAndSignUp.Interfaces;
using System.Numerics;
using SignInAndSignUp.Models;
using SignInAndSignUp.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace SignInAndSignUp.Services
{
    public class UserService : IManageUser
    {
        private IRepo<string, Users> _userRepo;
        private readonly IRepo<string, TravelAgent> _travelAgentRepo;
        private readonly IRepo<string, Traveller> _travellerRepo;
        private IGenerateToken _tokenService;

        public UserService(IRepo<string, Users> userrepo, IRepo<string, TravelAgent> travelAgentRepo, IRepo<string, Traveller> travellerRepo, IGenerateToken tokenService)
        {
            _userRepo = userrepo;
            _travelAgentRepo = travelAgentRepo;
            _travellerRepo = travellerRepo;
            _tokenService = tokenService;
        }

        public async Task<UserDTO?> Login(UserDTO user)
        {
            var userData = await _userRepo.Get(user.EmailId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserDTO();
                user.UserId = userData.UserId;
                user.EmailId = userData.EmailId;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
                return user;
            }
            return null;

        }

        public async Task<UserDTO?> TravelAgentRegistrationDTO(TravelAgentRegistrationDTO travelAgentRegistration)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            travelAgentRegistration.Users = new Users();
            travelAgentRegistration.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(travelAgentRegistration.PasswordClear));
            travelAgentRegistration.Users.PasswordKey = hmac.Key;
            travelAgentRegistration.Users.EmailId = travelAgentRegistration.Email;
            travelAgentRegistration.IsApproved = "Not approved";
            travelAgentRegistration.Users.Role = "Agent";
            var userResult = await _userRepo.Add(travelAgentRegistration.Users);
            var travelAgentResult = await _travelAgentRepo.Add(travelAgentRegistration);
            if (userResult != null && travelAgentResult != null)
            {
                user = new UserDTO();
                user.UserId = travelAgentResult.Users.UserId;
                user.EmailId = userResult.EmailId;
                user.Role = userResult.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
    }
}
