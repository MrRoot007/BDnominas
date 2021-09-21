using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Nomina2018.Core.CustomEntities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Core.Services;
using Nomina2018.Infrastructure.Data;
using Nomina2018.Infrastructure.Interfaces;
using Nomina2018.Infrastructure.Options;
using Nomina2018.Infrastructure.Repositories;
using Nomina2018.Infrastructure.Services;
using System;
using System.IO;

namespace Nomina2018.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BDNOMINA2018Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Nominas2018"))
            );
        }
        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
        }
        public static void AddServices(this IServiceCollection services)
        {

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
        }
        public static void AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Nominas 2018", Version = "v1" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });
        }
    }
}
