using System;
using System.Threading;
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


            Thread.Sleep(10000);

            foreach (var config in configuration1.AsEnumerable())
            {
                Console.WriteLine($"Key: {config.Key}, Value: {config.Value}");
            }

            Console.ReadLine();
        }
    }
}
