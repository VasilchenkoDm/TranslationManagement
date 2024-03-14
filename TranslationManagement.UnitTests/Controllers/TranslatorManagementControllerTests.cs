using Microsoft.AspNetCore.Mvc;
using TranslationManagement.Api.Controlers;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.UnitTests.Controllers
{
    public class TranslatorManagementControllerTests
    {
        private readonly ITranslatorService _translatorService;

        public TranslatorManagementControllerTests()
        {
            _translatorService = A.Fake<ITranslatorService>();
        }

        [Fact]
        public async void GetTranslatorsShouldBeOkObjectResult()
        {
            //Arrange 
            var controller = new TranslatorManagementController(_translatorService);

            //Act
            var result = await controller.GetTranslators();

            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void AddTranslatorShouldBeNoContentResult()
        {
            //Arrange 
            var translatorModel = A.Fake<RequestCreateTranslatorModel>();
            var controller = new TranslatorManagementController(_translatorService);

            //Act
            var result = await controller.CreateTranslator(translatorModel);

            //Assert
            result.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async void UpdateTranslatorStatusShouldBeNoContentResult()
        {
            //Arrange 
            var updateStatusTranslatorModel = A.Fake<RequestUpdateStatusTranslatorModel>();
            var controller = new TranslatorManagementController(_translatorService);

            //Act
            var result = await controller.UpdateTranslatorStatus(updateStatusTranslatorModel);

            //Assert
            result.Should().BeOfType(typeof(NoContentResult));
        }

    }
}
