using FluentValidation.AspNetCore;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Application.Models.FileUploadProcess;
using InsuranceConsultingOffice.Application.Services;
using System.Reflection;

namespace InsuranceConsultingOffice.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration); // Create an IConfiguration instance for the entire app
            //services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic)));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IPolicyApplication, PolicyApplication>();
            services.AddScoped<IInsuredsApplication, InsuredsApplication>();
            services.AddScoped<IFileUploadCodeAssign, FileUploadCodeAssign>();
            services.AddScoped<IFileUploadProcess, FileUploadProcess>();

            return services;
        }
    }
}
