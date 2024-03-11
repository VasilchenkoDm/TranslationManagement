using Microsoft.EntityFrameworkCore;
using TranslationManagement.DataAccess.Entities.Base;

namespace TranslationManagement.DataAccess.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            IQueryable<T> request = _entities.Where(item => item.Id == id);
            return await request.SingleAsync();
        }

        public async Task<int> Insert(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            //await _context.SaveChangesAsync();
        }

    }
}
