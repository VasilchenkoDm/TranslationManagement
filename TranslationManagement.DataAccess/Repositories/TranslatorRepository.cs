using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Translator>> GetList(string translatorName)
        {
            IQueryable<Translator> request = _entities.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(translatorName))
            {
                request = request.Where(translator => translator.Name.ToUpper() == translatorName.ToUpper());
            }

            return await request.ToListAsync();
        }

    }
}
