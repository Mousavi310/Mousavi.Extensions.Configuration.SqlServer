# Mousavi.Extensions.Configuration.SqlServer

This repository helps you to read your configuration from a SQL Server database. To add the provider in your ASP.NET Core application:

``` csharp
 public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((context, builder) =>
                    {
                        //Add this
                        builder.AddSqlServer(
                            "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)");
                    });
```

And in your console application:

``` csharp
var configuration1 = new ConfigurationBuilder()
                .AddSqlServer("Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)")
                .Build();
```

You can see samples directory for more information.
