using Microsoft.EntityFrameworkCore;
using SignInAndSignUp.Interfaces;
using SignInAndSignUp.Models;
using SignInAndSignUp.Services;

namespace UnitTesting1
{
    [TestClass]
    public class UnitTest1
    {
        public DbContextOptions<Context> GetDbcontextOption()
        {
            var contextOptions = new DbContextOptionsBuilder<Context>()
                                   .UseInMemoryDatabase(databaseName: "testMemory")
                                    .Options;
            return contextOptions;
        }
        [TestMethod]
        public async Task TestGetAllAgents()
        {
            using (var userContext = new Context(GetDbcontextOption()))
            {

                userContext.TravelAgents.Add(new TravelAgent
                {
                    TravelAgentId = 1,
                    Name = "ganapriya",
                    DateOfBirth = new DateTime(2001,09,12),
                    Email = "gana18@gmail.com",
                    AgencyName = "ganatours",
                    Address = "12,karapakkam",
                    Phone = "1234567890",
                    IsApproved = "Not Approved",
                    GSTNumber="ertyu",
                    Users = new Users() { UserId = 1, EmailId = "gana18@gmail.com", PasswordHash = new byte[] { }, PasswordKey = new byte[] { }, Role = "TravelAgent" },
                }) ; ; ;
                await userContext.SaveChangesAsync();
                IRepo<TravelAgent, string> repo = new TravellerAgentRepo(userContext);
                var data = await repo.GetAll();
                Assert.AreEqual(1, data.ToList().Count);


            }

        }

    }
}
