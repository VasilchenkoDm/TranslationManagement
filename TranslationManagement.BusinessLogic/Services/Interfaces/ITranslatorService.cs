using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslatorService
    {
        Task<ResponseGetListTranslatorModel> GetList(string translatorName = default);
        Task Add(RequestAddTranslatorModel requestModel);
        Task UpdateStatus(RequestUpdateStatusTranslatorModel requestModel);
    }
}