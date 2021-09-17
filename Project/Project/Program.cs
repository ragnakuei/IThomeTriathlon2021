using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NLog.Web;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var processPath    = AppDomain.CurrentDomain.BaseDirectory;
            var nlogConfigPath = Path.Combine(processPath, "3rd Party", "NLog", "nlog.config");
            NLogBuilder.ConfigureNLog(nlogConfigPath).GetCurrentClassLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseNLog()
                .ConfigureWebHostDefaults(webBuilder =>
                                          {
                                              webBuilder.UseStartup<Startup>();
                                          });
    }
}
