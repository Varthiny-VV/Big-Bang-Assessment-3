using SignInAndSignUp.Interfaces;
using SignInAndSignUp.Models;
using SignInAndSignUp.Models.DTO;

namespace SignInAndSignUp.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepo<TravelAgent, string> _agentRepo;
        public AdminService(IRepo<TravelAgent, string> agentRepo)
        {
            _agentRepo = agentRepo;
        }
        public async Task<TravelAgent?> UpdateStatus(ApproveStatus status)
        {
            try
            {
                var agent = await _agentRepo.Get(status.TravelAgentEmail);
                if (agent == null) { return null; }
                agent.IsApproved = status.Status;
                var updatedAgent = await _agentRepo.Update(agent);
                if (updatedAgent == null) { return null; }
                return updatedAgent;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
