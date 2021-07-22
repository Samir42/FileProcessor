using FileProcessor.Application.Contracts.Persistence;
using FileProcessor.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileProcessor.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileProcessorDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FileProcessorConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImportRepository, ImportRepository>();
                
            return services;
        }
    }
}
