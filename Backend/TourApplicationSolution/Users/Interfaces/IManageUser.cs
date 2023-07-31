using SignInAndSignUp.Models.DTO;

namespace SignInAndSignUp.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO?> Login(UserDTO user);
        public Task<UserDTO?> TravellerRegistration(TravellerRegistrationDTO travellerRegistration);
        public Task<UserDTO?> TravelAgentRegistration(TravelAgentRegistrationDTO travelAgentRegistration);
    }
}
