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
        private IRepo<Users,string> _userRepo;
        private readonly IRepo<TravelAgent,string> _travelAgentRepo;
        private readonly IRepo<Traveller, string> _travellerRepo;
        private IGenerateToken _tokenService;

        public UserService(IRepo<Users, string> userrepo, IRepo<TravelAgent, string> travelAgentRepo, IRepo<Traveller, string> travellerRepo, IGenerateToken tokenService)
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

        public async Task<UserDTO?> TravelAgentRegistration(TravelAgentRegistrationDTO travelAgentRegistration)
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

        public async Task<UserDTO?> TravellerRegistration(TravellerRegistrationDTO travellerRegistration)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            travellerRegistration.Users = new Users();
            travellerRegistration.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(travellerRegistration.PasswordClear));
            travellerRegistration.Users.PasswordKey = hmac.Key;
            travellerRegistration.Users.EmailId = travellerRegistration.Email;
            travellerRegistration.Users.Role = "Traveller";
            var userResult = await _userRepo.Add(travellerRegistration.Users);

            var travellerResult = await _travellerRepo.Add(travellerRegistration);
            if (userResult != null && travellerResult != null) 
            {
                user = new UserDTO(); 
                user.UserId = userResult.UserId;
                user.Role = userResult.Role;
                user.EmailId= userResult.EmailId;
                user.EmailId = travellerResult.Email;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

       
    }
}
