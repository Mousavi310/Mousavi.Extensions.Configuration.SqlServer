using System;
using System.Globalization;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerConfigurationSourceBuilder : ISqlServerConfigurationSourceBuilder
    {
        public string ConnectionString { get; private set; }
        public string Table { get; private set; }
        public string KeyColumn { get; private set; }
        public string ValueColumn { get; private set; }
        public string Schema { get; private set; }
        public TimeSpan? PeriodicalRefreshTimeSpan { get; private set; }


        public ISqlServerConfigurationSourceBuilder UseConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException($"Connection string could not be null or empty!");
            }

            ConnectionString = connectionString;

            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
            {
                throw new ArgumentNullException($"Table could not be null or empty!");
            }

            Table = table;

            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithKeyColumn(string keyColumn)
        {
            if (string.IsNullOrWhiteSpace(keyColumn))
            {
                throw new ArgumentNullException($"Key column could not be null or empty!");
            }
            KeyColumn = keyColumn;
            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithValueColumn(string valueColumn)
        {
            if (string.IsNullOrWhiteSpace(valueColumn))
            {
                throw new ArgumentNullException($"Value column could not be null or empty!");
            }
            ValueColumn = valueColumn;
            return this;
        }

        public ISqlServerConfigurationSourceBuilder WithSchema(string schema)
        {
            if (string.IsNullOrWhiteSpace(schema))
            {
                throw new ArgumentNullException($"Schema could not be null or empty!");
            }

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
            var instance = new SqlServerConfigurationSource {ConnectionString = ConnectionString};

            if (Table != null)
                instance.Table = Table;

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
