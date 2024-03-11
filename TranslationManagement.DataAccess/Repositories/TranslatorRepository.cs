using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Base;
using TranslationManagement.DataAccess.Repositories.Interfaces;

namespace TranslationManagement.DataAccess.Repositories
{
    public class TranslatorRepository : BaseRepository<Translator>, ITranslatorRepository
    {
        public TranslatorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
