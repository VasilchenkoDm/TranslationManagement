﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using TranslationManagement.DataAccess.Repositories;
using TranslationManagement.DataAccess.Repositories.Interfaces;

namespace TranslationManagement.DataAccess
{
    public static class Startup
    {
        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            AddDbContext(services);
            RegisterDependencies(services);
            // automatic startup database migration
            MigrateDatabase(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlite("Data Source=TranslationAppDatabase.db"));
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<ITranslatorRepository, TranslatorRepository>();
            services.AddScoped<ITranslationJobRepository, TranslationJobRepository>();
        }

        private static void MigrateDatabase(IServiceCollection services) 
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ApplicationDbContext context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }

    }
}
