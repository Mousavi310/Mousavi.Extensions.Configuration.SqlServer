using System;
using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public static class SqlServerConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, string connectionString)
        {
            return builder.AddSqlServer(s => { s.ConnectionString = connectionString; });
        }

        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder,
            Action<SqlServerConfigurationSource> configureSource)
        {
            return builder.Add(configureSource);
        }
    }
}
