using Microsoft.Extensions.DependencyInjection;
using TranslationManagement.DataAccess;

namespace TranslationManagement.BusinessLogic
{
    public static class Startup
    {
        public static void ConfigureBusinessLogic(this IServiceCollection services)
        {
            services.ConfigureDataAccess();
            AddDependecies(services);
        }

        private static void AddDependecies(IServiceCollection services)
        {
            //services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
            //services.AddScoped<IEmailSender, GmailEmailSender>();
            //services.AddScoped<IDateTimeHelper, DateTimeHelper>();

            //services.AddScoped<IIdentityService, IdentityService>();
            //services.AddScoped<IWiseTaskService, WiseTaskService>();
            //services.AddScoped<IActivityTypeService, ActivityTypeService>();
            //services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
