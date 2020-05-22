using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Mousavi.Extensions.Configuration.SqlServer;

namespace AspNetCoreSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.AddSqlServer(
                            "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)",
                            TimeSpan.FromSeconds(5));

                        builder.AddSqlServer(
                            sqlBuilder => sqlBuilder
                                .UseConnectionString(
                                    "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)")
                                .EnablePeriodicalAutoRefresh(TimeSpan.FromSeconds(5)));
                    });
    }
}
