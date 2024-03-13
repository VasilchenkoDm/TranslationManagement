using Microsoft.EntityFrameworkCore;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.DataAccess.Repositories.Base;
using TranslationManagement.DataAccess.Repositories.Interfaces;
using TranslationManagement.Shared.Enums;

namespace TranslationManagement.DataAccess.Repositories
{
    public class TranslatorRepository : BaseRepository<Translator>, ITranslatorRepository
    {
        public TranslatorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Translator>> GetList(string name = "", string status = "")
        {
            IQueryable<Translator> request = _entities.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(name))
            {
                request = request.Where(translator => translator.Name.ToUpper() == name.ToUpper());
            }
            if (Enum.TryParse(status, out TranslatorStatusEnum translatorStatus)) 
            {
                request = request.Where(translator => translator.Status == translatorStatus);
            }

            return await request.ToListAsync();
        }

    }
}
