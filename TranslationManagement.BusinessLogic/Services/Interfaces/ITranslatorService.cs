using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslatorService
    {
        Task<ResponseGetListTranslatorModel> GetList(string translatorName = default);
        Task<bool> Add(RequestAddTranslatorModel requestModel);
        Task<string> UpdateStatus(RequestUpdateStatusTranslatorModel requestModel);
    }
}