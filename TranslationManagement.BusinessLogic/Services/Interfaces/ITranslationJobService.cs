using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Services.Interfaces
{
    public interface ITranslationJobService
    {
        Task<ResponseGetListTranslationJobModel> GetList();
        Task Create(RequestCreateTranslationJobModel requestModel);
        Task CreateWithFile(RequestCreateWithFileTranslationJobModel requestModel);
        Task UpdateStatus(RequestUpdateStatusTranslationJobModel requestModel);
        Task Assign(RequestAssignTranslationJobModel requestModel);
    }
}
