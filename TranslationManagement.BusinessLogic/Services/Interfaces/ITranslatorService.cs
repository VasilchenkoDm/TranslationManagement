using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslatorService
    {
        Task<ResponseGetListTranslatorModel> GetList(string translatorName = "", string translatorStatus = "");
        Task Add(RequestAddTranslatorModel requestModel);
        Task UpdateStatus(RequestUpdateStatusTranslatorModel requestModel);
    }
}