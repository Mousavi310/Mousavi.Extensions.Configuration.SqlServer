using System;
using System.Collections.Generic;
using System.Text;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerConfigurationSourceBuilder : ISqlServerConfigurationSourceBuilder
    {
        public string ConnectionString { get; private set; }
        public string KeyColumn { get; private set; }
        public string ValueColumn { get; private set; }
        public string Schema { get; private set; }
        public TimeSpan? PeriodicalRefreshTimeSpan { get; set; }


        public ISqlServerConfigurationSourceBuilder UseConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithKeyColumn(string keyColumn)
        {
            KeyColumn = keyColumn;
            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithValueColumn(string valueColumn)
        {
            ValueColumn = valueColumn;
            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithSchema(string schema)
        {
            Schema = schema;
            return this;
        }

        public ISqlServerConfigurationSourceBuilder EnablePeriodicalAutoRefresh(TimeSpan refreshInterval)
        {
            if(refreshInterval < TimeSpan.Zero)
                throw new Exception($"Refresh interval must be positive.");

            PeriodicalRefreshTimeSpan = refreshInterval;
            return this;
        }

        public SqlServerConfigurationSource Build()
        {
            var instance = new SqlServerConfigurationSource();

            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new Exception($"Connection string could not be null or empty!");
            }
            
            instance.ConnectionString = ConnectionString;

            if (KeyColumn != null)
                instance.KeyColumn = KeyColumn;

            if (ValueColumn != null)
                instance.ValueColumn = ValueColumn;

            if (Schema != null)
                instance.Schema = Schema;

            if (PeriodicalRefreshTimeSpan != null)
                instance.SqlServerWatcher = new SqlServerPeriodicalWatcher(PeriodicalRefreshTimeSpan.Value);

            return instance;
        }
    }
}
