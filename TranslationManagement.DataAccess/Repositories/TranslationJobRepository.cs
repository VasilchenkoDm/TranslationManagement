using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Base;
using TranslationManagement.DataAccess.Repositories.Interfaces;

namespace TranslationManagement.DataAccess.Repositories
{
    public class TranslationJobRepository : BaseRepository<TranslationJob>, ITranslationJobRepository
    {
        public TranslationJobRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
