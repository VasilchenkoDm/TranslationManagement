﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.Shared.Constants;
using TranslationManagement.Shared.Enums;
using TranslationManagement.ViewModels.TranslationJob;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services
{
    public class TranslatorService : ITranslatorService
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ILogger<TranslatorService> _logger;

        public TranslatorService(IMapper mapper, ILogger<TranslatorService> logger, 
            ITranslatorRepository translatorRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _translatorRepository = translatorRepository;
        }

        public async Task<ResponseGetListTranslatorModel> GetList(string translatorName = "", string translatorStatus = "")
        {
            IEnumerable<Translator> translators = await _translatorRepository.GetList(translatorName, translatorStatus);
            var responseModel = new ResponseGetListTranslatorModel();
            responseModel.Items = _mapper.Map<IEnumerable<GetListTranslatorModelItem>>(translators);
            return responseModel;
        }

        public async Task Create(RequestCreateTranslatorModel requestModel)
        {
            var translator = _mapper.Map<RequestCreateTranslatorModel, Translator>(requestModel);
            await _translatorRepository.Insert(translator);
        }

        public async Task UpdateStatus(RequestUpdateStatusTranslatorModel requestModel)
        {
            _logger.LogInformation($"User status update request: {requestModel.Status} for user {requestModel.Id}");
            if (!Enum.TryParse(requestModel.Status, out TranslatorStatusEnum translatorStatus))
            {
                throw new ArgumentException(ExceptionMessageConstants.UnknownStatus);
            }
            Translator translator = await _translatorRepository.GetById(requestModel.Id);
            if (translator is null)  
            {
                throw new KeyNotFoundException(ExceptionMessageConstants.TranslatorNotFound);
            }
            translator.Status = translatorStatus;
            await _translatorRepository.Update(translator);
        }

    }
}
