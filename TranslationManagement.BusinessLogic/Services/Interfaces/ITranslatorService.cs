using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslatorService
    {
        Task<ResponseGetListTranslatorModel> GetList(string translatorName = "", string translatorStatus = "");
        Task Create(RequestCreateTranslatorModel requestModel);
        Task UpdateStatus(RequestUpdateStatusTranslatorModel requestModel);
    }
}