using SignInAndSignUp.Models;
using SignInAndSignUp.Models.DTO;

namespace SignInAndSignUp.Interfaces
{
    public interface IAdminService
    {
        public Task<TravelAgent?> UpdateStatus(ApproveStatus status);
    }
}
