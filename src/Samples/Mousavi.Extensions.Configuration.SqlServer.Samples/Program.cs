using System;
using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration1 = new ConfigurationBuilder()
                .AddSqlServer("Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)")
                .Build();

            foreach (var config in configuration1.AsEnumerable())
            {
                Console.WriteLine($"Key: {config.Key}, Value: {config.Value}");
            }


            var configuration2 = new ConfigurationBuilder()
                .AddSqlServer(c =>
                {
                    c.ConnectionString =
                        "Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)";
                    c.Schema = "config";
                    c.Table = "Settings";
                })
                .Build();

            foreach (var config in configuration2.AsEnumerable())
            {
                Console.WriteLine($"Key: {config.Key}, Value: {config.Value}");
            }
        }
    }
}
