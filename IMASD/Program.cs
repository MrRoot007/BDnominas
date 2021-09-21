using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nomina2018.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMASD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var hostServer = CreateHostBuilder(args).Build();
            //using (var enviroment = hostServer.Services.CreateScope())
            //{
            //    var services = enviroment.ServiceProvider;
            //    try
            //    {
            //        //var userManager = services.GetRequiredService<>
            //        var context = services.GetRequiredService<BDNOMINA2018Context>();
            //        context.Database.Migrate();
            //    }
            //    catch (Exception error)
            //    {
            //        var loggin = services.GetRequiredService<ILogger<Program>>();
            //        loggin.LogError(error, "Ocurrio un error en la migración");
            //    }
            //}
            //hostServer.Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
