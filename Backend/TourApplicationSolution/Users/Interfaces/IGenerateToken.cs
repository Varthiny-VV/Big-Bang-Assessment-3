using SignInAndSignUp.Models.DTO;

namespace SignInAndSignUp.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);
    }
}
