using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslationJobService
    {
        Task<ResponseGetListTranslationJobModel> GetList();
        Task Add(RequestAddTranslationJobModel requestModel);
        Task AddWithFile(RequestAddWithFileTranslationJobModel requestModel);
        Task UpdateStatus(RequestUpdateStatusTranslationJobModel requestModel);
    }
}
