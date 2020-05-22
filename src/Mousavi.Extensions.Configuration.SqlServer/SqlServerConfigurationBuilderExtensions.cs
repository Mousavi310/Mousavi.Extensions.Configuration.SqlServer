using System;
using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public static class SqlServerConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, string connectionString)
        {
            return builder.AddSqlServer(sqlBuilder => sqlBuilder.UseConnectionString(connectionString));
        }

        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, 
            string connectionString, 
            TimeSpan periodicalRefreshInterval)
        {
            return builder.AddSqlServer(sqlBuilder => sqlBuilder
                .UseConnectionString(connectionString)
                .EnablePeriodicalAutoRefresh(periodicalRefreshInterval)
            );
        }


        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder,
            Action<ISqlServerConfigurationSourceBuilder> sqlBuilderAction)
        {
            var sqlBuilder = new SqlServerConfigurationSourceBuilder();
            sqlBuilderAction(sqlBuilder);
            var source = sqlBuilder.Build();
            return builder.Add(source);
        }
    }
}
