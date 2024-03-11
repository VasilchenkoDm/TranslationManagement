using TranslationManagement.DataAccess.Entities.Base;

namespace TranslationManagement.DataAccess.Repositories.Base
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        Task<int> Insert(T entity);
        Task Update(T entity);
    }
}
