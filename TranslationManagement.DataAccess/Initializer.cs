using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.Shared.Enums;

namespace TranslationManagement.DataAccess
{
    public static class Initializer
    {
        public static void Init(IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ApplicationDbContext context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            CreateTranslators(context).GetAwaiter().GetResult();
        }

        private static async Task CreateTranslators(ApplicationDbContext context)
        {
            if (context.Translators.Any())
            {
                return;
            }
            var translators = new List<Translator>
            {                        
                new Translator { Name = "Steffan Clio", Status = TranslatorStatusEnum.Applicant },
                new Translator { Name = "Albina Aeolus", Status = TranslatorStatusEnum.Certified },
                new Translator { Name = "Sabella Betrys", Status = TranslatorStatusEnum.Deleted }
            };
            await context.AddRangeAsync(translators);
            await context.SaveChangesAsync();
        }
    }
}
