using JobApplication.Infra.Domain;
using Microsoft.EntityFrameworkCore;

namespace DEMO_PROJECT.Configurations
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Default"];

            services.AddDbContext<MyDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("JobApplication.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Singleton);
        }
    }
}
