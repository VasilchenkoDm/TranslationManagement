using Microsoft.EntityFrameworkCore;
using TranslationManagement.DataAccess.Entities;

namespace TranslationManagement.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TranslationJob> TranslationJobs { get; set; }
        public DbSet<Translator> Translators { get; set; }

    }
}
