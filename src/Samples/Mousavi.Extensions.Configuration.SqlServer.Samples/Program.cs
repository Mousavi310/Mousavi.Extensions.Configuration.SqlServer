using System;
using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddSqlServer("Server=localhost;Database=Example;User Id=sa;Password=your(#SecurePassword!123)")
                .Build();

            foreach (var config in configuration.AsEnumerable())
            {
                Console.Write($"Key: {config.Key}, Value: {config.Value}");
            }

        }
    }
}
