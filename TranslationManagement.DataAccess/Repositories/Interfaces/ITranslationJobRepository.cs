using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Base;

namespace TranslationManagement.DataAccess.Repositories.Interfaces
{
    public interface ITranslationJobRepository : IBaseRepository<TranslationJob>
    {
        public Task<IEnumerable<TranslationJob>> GetList();
    }
}
