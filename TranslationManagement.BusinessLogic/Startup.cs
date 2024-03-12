using AutoMapper;
using External.ThirdParty.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TranslationManagement.BusinessLogic.Services;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces;
using TranslationManagement.DataAccess;

namespace TranslationManagement.BusinessLogic
{
    public static class Startup
    {
        public static void ConfigureBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDataAccess(configuration);
            AddDependecies(services);
            AddAutoMapper(services);
        }

        private static void AddDependecies(IServiceCollection services)
        {
            services.AddScoped<INotificationService, UnreliableNotificationService>();
            services.AddScoped<ITranslationJobFileReader, TranslationJobFileReader>();

            services.AddScoped<ITranslatorService, TranslatorService>();
            services.AddScoped<ITranslationJobService, TranslationJobService>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(Assembly.GetExecutingAssembly());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
