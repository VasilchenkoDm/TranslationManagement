using AutoMapper;
using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.Shared.Constants;
using TranslationManagement.Shared.Enums;
using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Services
{
    public class TranslationJobService : ITranslationJobService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TranslationJobService> _logger;
        private readonly ITranslationJobRepository _translationJobRepository;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly INotificationService _notificationService;
        private readonly ITranslationJobFileReader _translationJobFileReader;

        public TranslationJobService(IMapper mapper, ILogger<TranslationJobService> logger, 
            ITranslationJobRepository translationJobRepository, ITranslatorRepository translatorRepository, 
            INotificationService notificationService, ITranslationJobFileReader translationJobFileReader)
        {
            _mapper = mapper;
            _logger = logger;
            _translationJobRepository = translationJobRepository;
            _translatorRepository = translatorRepository;
            _notificationService = notificationService;
            _translationJobFileReader = translationJobFileReader;
        }

        public async Task<ResponseGetListTranslationJobModel> GetList()
        {
            IEnumerable<TranslationJob> translationJobs = await _translationJobRepository.GetList();
            var responseModel = new ResponseGetListTranslationJobModel();
            responseModel.Items = _mapper.Map<IEnumerable<GetListTranslationJobModelItem>>(translationJobs);
            return responseModel;
        }

        public async Task Create(RequestAddTranslationJobModel requestModel)
        {
            var translationJob = _mapper.Map<RequestAddTranslationJobModel, TranslationJob>(requestModel);
            translationJob.Status = TranslationJobStatusEnum.New;
            translationJob.Price = CalculatePrice(translationJob.OriginalContent.Length);
            int translationJobId = await _translationJobRepository.Insert(translationJob);
            while (!_notificationService.SendNotification("Job created: " + translationJobId).Result)
            {
            }
            _logger.LogInformation("New job notification sent");
        }

        public Task CreateWithFile(RequestAddWithFileTranslationJobModel requestModel)
        {
            TranslationJobModel translationJob = _translationJobFileReader.ReadFile(requestModel.File);
            var newJob = new RequestAddTranslationJobModel();
            newJob.OriginalContent = translationJob.Content;
            newJob.CustomerName = string.IsNullOrEmpty(translationJob.Customer) ? 
                requestModel.CustomerName : translationJob.Customer;
            return Create(newJob);
        }

        public async Task UpdateStatus(RequestUpdateStatusTranslationJobModel requestModel)
        {
            _logger.LogInformation($"Job status update request received: {requestModel.Status} for job {requestModel.Id} by translator {requestModel.TranslatorId}");
            if (!Enum.TryParse(requestModel.Status, out TranslationJobStatusEnum translationJobStatus))
            {
                throw new ArgumentException("invalid status");
            }
            TranslationJob translationJob = await _translationJobRepository.GetById(requestModel.Id);
            if (translationJob is null)
            {
                throw new KeyNotFoundException("translation job not found");
            }
            if (IsNewStatusValid(translationJobStatus, translationJob.Status))
            {
                throw new ArgumentException("invalid status change");
            }
            translationJob.Status = translationJobStatus;
            await _translationJobRepository.Update(translationJob);
        }

        private bool IsNewStatusValid(TranslationJobStatusEnum newStatus, TranslationJobStatusEnum oldStatus) 
        {
            bool isStatusValid = (oldStatus == TranslationJobStatusEnum.New && newStatus == TranslationJobStatusEnum.Completed) ||
                oldStatus == TranslationJobStatusEnum.Completed || newStatus == TranslationJobStatusEnum.New;
            return isStatusValid;
        }

        private decimal CalculatePrice(int contentLength)
        {
            return contentLength * TranslationJobConstants.PricePerCharacter;
        }

        public async Task Assign(RequestAssignTranslationJobModel requestModel)
        {
            TranslationJob translationJob = await _translationJobRepository.GetById(requestModel.Id);
            if (translationJob is null)
            {
                throw new KeyNotFoundException("translation job not found");
            }
            Translator translator = await _translatorRepository.GetById(requestModel.TranslatorId);
            if (translator is null)
            {
                throw new KeyNotFoundException("translator not found");
            }
            if (translator.Status != TranslatorStatusEnum.Certified)
            {
                throw new ArgumentException("only Certified translators can work on jobs");
            }
            translationJob.TranslatorId = translator.Id;
            await _translationJobRepository.Update(translationJob);
        }

    }
}
