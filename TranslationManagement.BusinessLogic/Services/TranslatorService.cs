using AutoMapper;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.Shared.Enums;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services
{
    public class TranslatorService : ITranslatorService
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorRepository _translatorRepository;

        public TranslatorService(IMapper mapper, ITranslatorRepository translatorRepository)
        {
            _mapper = mapper;
            _translatorRepository = translatorRepository;
        }

        public async Task<ResponseGetListTranslatorModel> GetList(string translatorName = default)
        {
            IEnumerable<Translator> translators = await _translatorRepository.GetList(translatorName);
            var responseModel = _mapper.Map<ResponseGetListTranslatorModel>(translators);
            return responseModel;
        }

        public async Task<bool> Add(RequestAddTranslatorModel requestModel)
        {
            var translator = _mapper.Map<RequestAddTranslatorModel, Translator>(requestModel);
            int translatorId = await _translatorRepository.Insert(translator);
            return translatorId > 0;
        }

        public async Task<string> UpdateStatus(RequestUpdateStatusTranslatorModel requestModel)
        {
            if (!Enum.TryParse(requestModel.Status, out TranslatorStatusEnum translatorStatus))
            {
                throw new ArgumentException("unknown status");
            }
            Translator translator = await _translatorRepository.GetById(requestModel.Id);
            if (translator is null)  
            {
                throw new KeyNotFoundException("translator not found");
            }
            translator.Status = translatorStatus;
            await _translatorRepository.Update(translator);
            return "updated";
        }

    }
}
