using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TranslationManagement.BusinessLogic.Services;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.Shared.Enums;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.UnitTests.Services
{
    public class TranslatorServiceTests
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ILogger<TranslatorService> _logger;
        private readonly IMapper _mapper;

        public TranslatorServiceTests()
        {
            _translatorRepository = A.Fake<ITranslatorRepository>();
            _logger = A.Fake<ILogger<TranslatorService>>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async void GetListShouldNotBeNull()
        {
            //Arrange 
            var service = new TranslatorService(_mapper, _logger, _translatorRepository);

            //Act
            var result = await service.GetList();

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async void AddShouldNotThrow()
        {
            //Arrange 
            var translatorModel = A.Fake<RequestCreateTranslatorModel>();
            var service = new TranslatorService(_mapper, _logger, _translatorRepository);

            //Act                       
            Func<Task> result = async () => {
                await service.Create(translatorModel);
            };

            //Assert
            await result.Should().NotThrowAsync();
        }

        [Fact]
        public async void UpdateStatusShouldNotThrow()
        {
            //Arrange 
            var updateStatusTranslatorModel = A.Fake<RequestUpdateStatusTranslatorModel>();
            updateStatusTranslatorModel.Status = TranslatorStatusEnum.Certified.ToString();

            var service = new TranslatorService(_mapper, _logger, _translatorRepository);

            //Act                       
            Func<Task> result = async () => {
                await service.UpdateStatus(updateStatusTranslatorModel);
            };

            //Assert
            await result.Should().NotThrowAsync();
        }

        [Fact]
        public async void UpdateStatusShouldThrowArgumentException()
        {
            //Arrange 
            var updateStatusTranslatorModel = A.Fake<RequestUpdateStatusTranslatorModel>();
            updateStatusTranslatorModel.Status = string.Empty;

            var service = new TranslatorService(_mapper, _logger, _translatorRepository);

            //Act                       
            Func<Task> result = async () => {
                await service.UpdateStatus(updateStatusTranslatorModel);
            };

            //Assert
            await result.Should().ThrowExactlyAsync<ArgumentException>();
        }

    }
}
