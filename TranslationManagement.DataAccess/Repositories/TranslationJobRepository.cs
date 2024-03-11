using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TranslationJob>> GetList()
        {
            IQueryable<TranslationJob> request = _entities.AsNoTracking();
            return await request.ToListAsync();
        }

    }
}
