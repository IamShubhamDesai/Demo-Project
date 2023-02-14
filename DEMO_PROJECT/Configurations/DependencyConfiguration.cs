using JobApplication.Core.Contact;
using JobApplication.Core.Service;
using JobApplication.Infra.Contract;
using JobApplication.Infra.Repository;

namespace DEMO_PROJECT.Configurations
{
    public static class DependencyConfiguration
    {
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmployeeServices, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
