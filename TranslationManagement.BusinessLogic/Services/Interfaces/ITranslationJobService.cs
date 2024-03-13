using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslationJobService
    {
        Task<ResponseGetListTranslationJobModel> GetList();
        Task Create(RequestAddTranslationJobModel requestModel);
        Task CreateWithFile(RequestAddWithFileTranslationJobModel requestModel);
        Task UpdateStatus(RequestUpdateStatusTranslationJobModel requestModel);
        Task Assign(RequestAssignTranslationJobModel requestModel);
    }
}
