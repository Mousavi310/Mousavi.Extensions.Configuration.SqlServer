using System;
using System.Collections.Generic;
using System.Text;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public interface ISqlServerConfigurationSourceBuilder
    {
        ISqlServerConfigurationSourceBuilder UseConnectionString(string connectionString);
        ISqlServerConfigurationSourceBuilder WithTable(string table);
        ISqlServerConfigurationSourceBuilder WithKeyColumn(string keyColumn);
        ISqlServerConfigurationSourceBuilder WithValueColumn(string valueColumn);
        ISqlServerConfigurationSourceBuilder WithSchema(string valueColumn);
        ISqlServerConfigurationSourceBuilder EnablePeriodicalAutoRefresh(TimeSpan refreshInterval);

        SqlServerConfigurationSource Build();
    }
}
