# Mousavi.Extensions.Configuration.SqlServer

This repository helps you to read your configuration from a SQL Server database. To add the provider in your ASP.NET Core application. First install the NuGet:

``` bash
dotnet add package Mousavi.Extensions.Configuration.SqlServer --version 0.3.4-g3467e37824
```
And then configure the provider:
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

You can choose the name of `table`, `schema`, `key column`, `value column`:

``` csharp
builder.AddSqlServer(
                sqlBuilder => sqlBuilder
                    .UseConnectionString(
                        "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)")
                    .WithSchema("dbo")
                    .WithKeyColumn("[Key]")
                    .WithValueColumn("[Value]"));
```

## Refresh Configuration
If you want refresh configuration data, you can specify refresh interval:

``` csharp
builder.AddSqlServer(
                "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)",
                TimeSpan.FromSeconds(5));
```

or 

``` csharp
builder.AddSqlServer(
                sqlBuilder => sqlBuilder
                    .UseConnectionString(
                        "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)")
                    .EnablePeriodicalAutoRefresh(TimeSpan.FromSeconds(5)));
```

Using the above configuration, the provider reload configuration from the database every 5 seconds.
You can see the samples directory for more information.
