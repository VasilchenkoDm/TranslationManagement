using AutoMapper;
using External.ThirdParty.Services;
using System.Xml.Linq;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.ViewModels.TranslationJob;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services
{
    public class TranslationJobService : ITranslationJobService
    {
        private readonly IMapper _mapper;
        private readonly ITranslationJobRepository _translationJobRepository;

        public TranslationJobService(IMapper mapper, ITranslationJobRepository translationJobRepository)
        {
            _mapper = mapper;
            _translationJobRepository = translationJobRepository;
        }

        public async Task<ResponseGetListTranslationJobModel> GetList()
        {
            IEnumerable<TranslationJob> translationJobs = await _translationJobRepository.GetList();
            var responseModel = _mapper.Map<ResponseGetListTranslationJobModel>(translationJobs);
            return responseModel;
        }

        public async Task<bool> Add(RequestAddTranslationJobModel requestModel)
        {
            var translationJob = _mapper.Map<RequestAddTranslationJobModel, TranslationJob>(requestModel);
            translationJob.Status = "New";
            SetPrice(translationJob);

            int translationJobId = await _translationJobRepository.Insert(translationJob);

            bool success = translationJobId > 0;
            if (success)
            {
                var notificationSvc = new UnreliableNotificationService();
                while (!notificationSvc.SendNotification("Job created: " + translationJobId).Result)
                {
                }

                //where log? 
                //_logger.LogInformation("New job notification sent");
            }
            return success;
        }

        public Task<bool> AddWithFile(RequestAddWithFileTranslationJobModel requestModel)
        {
            var reader = new StreamReader(requestModel.File.OpenReadStream());
            string content;

            if (requestModel.File.FileName.EndsWith(".txt"))
            {
                content = reader.ReadToEnd();
            }
            else if (requestModel.File.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                requestModel.CustomerName = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            var newJob = new RequestAddTranslationJobModel()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = requestModel.CustomerName,
            };

            //w twice? 
            //SetPrice(newJob);

            return Add(newJob);
        }

        static class JobStatuses
        {
            internal static readonly string New = "New";
            internal static readonly string Inprogress = "InProgress";
            internal static readonly string Completed = "Completed";
        }

        public async Task<string> UpdateStatus(RequestUpdateStatusTranslationJobModel requestModel)
        {
            if (typeof(JobStatuses).GetProperties().Count(prop => prop.Name == requestModel.Status) == 0)
            {
                return "invalid status";
            }

            TranslationJob translationJob = await _translationJobRepository.GetById(requestModel.Id);
            //translationJob is null? 

            bool isInvalidStatusChange = (translationJob.Status == JobStatuses.New && requestModel.Status == JobStatuses.Completed) ||
                                         translationJob.Status == JobStatuses.Completed || requestModel.Status == JobStatuses.New;
            if (isInvalidStatusChange)
            {
                return "invalid status change";
            }

            translationJob.Status = requestModel.Status;

            await _translationJobRepository.Update(translationJob);

            return "updated";
        }

        const double PricePerCharacter = 0.01;
        private void SetPrice(TranslationJob job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }


    }
}
