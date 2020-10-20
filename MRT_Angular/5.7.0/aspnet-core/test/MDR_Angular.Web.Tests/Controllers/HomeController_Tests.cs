using System.Threading.Tasks;
using MDR_Angular.Models.TokenAuth;
using MDR_Angular.Web.Controllers;
using Shouldly;
using Xunit;

namespace MDR_Angular.Web.Tests.Controllers
{
    public class HomeController_Tests: MDR_AngularWebTestBase
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