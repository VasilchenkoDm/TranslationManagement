using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Base;

namespace TranslationManagement.DataAccess.Repositories.Interfaces
{
    public interface ITranslatorRepository : IBaseRepository<Translator>
    {
        public Task<IEnumerable<Translator>> GetList(string name = "", string status = "");
    }
}
