using AutoMapper;
using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using TranslationManagement.BusinessLogic.Services;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.Shared.Constants;
using TranslationManagement.Shared.Enums;
using TranslationManagement.ViewModels.TranslationJob;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.UnitTests.Services
{
    public class TranslationJobServiceTests
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TranslationJobService> _logger;
        private readonly ITranslationJobRepository _translationJobRepository;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly INotificationService _notificationService;
        private readonly ITranslationJobFileReader _translationJobFileReader;

        public TranslationJobServiceTests()
        {
            _translatorRepository = A.Fake<ITranslatorRepository>();
            _translationJobRepository = A.Fake<ITranslationJobRepository>();
            _logger = A.Fake<ILogger<TranslationJobService>>();
            _mapper = A.Fake<IMapper>();
            _notificationService = A.Fake<INotificationService>();
            _translationJobFileReader = A.Fake<ITranslationJobFileReader>();
        }

        [Fact]
        public async void UpdateStatusShouldNotThrow()
        {
            //Arrange 
            var updateStatusTranslationJobModel = A.Fake<RequestUpdateStatusTranslationJobModel>();
            updateStatusTranslationJobModel.Status = TranslationJobStatusEnum.Inprogress.ToString();

            var service = new TranslationJobService(_mapper, _logger, _translationJobRepository, _translatorRepository, 
                _notificationService, _translationJobFileReader);

            //Act                       
            Func<Task> result = async () => {
                await service.UpdateStatus(updateStatusTranslationJobModel);
            };

            //Assert
            await result.Should().NotThrowAsync();
        }

        [Fact]
        public async void UpdateStatusShouldThrowArgumentException()
        {
            //Arrange 
            var updateStatusTranslationJobModel = A.Fake<RequestUpdateStatusTranslationJobModel>();
            updateStatusTranslationJobModel.Status = TranslationJobStatusEnum.Completed.ToString();

            var service = new TranslationJobService(_mapper, _logger, _translationJobRepository, _translatorRepository,
                _notificationService, _translationJobFileReader);

            //Act                       
            Func<Task> result = async () => {
                await service.UpdateStatus(updateStatusTranslationJobModel);
            };

            //Assert
            await result.Should().ThrowExactlyAsync<ArgumentException>().WithMessage(ExceptionMessageConstants.InvalidStatusChange);
        }

    }
}
