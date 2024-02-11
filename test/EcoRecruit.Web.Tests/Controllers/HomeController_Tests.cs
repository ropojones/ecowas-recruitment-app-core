using System.Threading.Tasks;
using EcoRecruit.Models.TokenAuth;
using EcoRecruit.Web.Controllers;
using Shouldly;
using Xunit;

namespace EcoRecruit.Web.Tests.Controllers
{
    public class HomeController_Tests: EcoRecruitWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}