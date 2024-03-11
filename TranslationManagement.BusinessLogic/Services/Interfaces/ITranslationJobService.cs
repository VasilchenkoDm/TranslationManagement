using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslationJobService
    {
        Task<ResponseGetListTranslationJobModel> GetList();
        Task<bool> Add(RequestAddTranslationJobModel requestModel);
        Task<bool> AddWithFile(RequestAddWithFileTranslationJobModel requestModel);
        Task<string> UpdateStatus(RequestUpdateStatusTranslationJobModel requestModel);
    }
}
