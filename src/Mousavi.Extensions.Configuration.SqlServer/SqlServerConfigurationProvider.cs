using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerConfigurationProvider : ConfigurationProvider, IDisposable
    {
        private readonly SqlServerConfigurationSource _source;
        private readonly string _query;
        private readonly IDisposable _changeTokenRegistration;

        public SqlServerConfigurationProvider(SqlServerConfigurationSource source)
        {
            _source = source;
            _query =$"select {_source.KeyColumn}, {_source.ValueColumn} from {_source.Schema}.[{_source.Table}]";

            if (_source.SqlServerWatcher != null)
            {
                _changeTokenRegistration = ChangeToken.OnChange(
                    () => _source.SqlServerWatcher.Watch(),
                    Load
                );
            }
        }
        public override void Load()
        {
            var dic = new Dictionary<string, string>();
            using (var connection = new SqlConnection(_source.ConnectionString))
            {
                var query = new SqlCommand(_query, connection);

                query.Connection.Open();

                using (var reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dic.Add(reader[0].ToString(), reader[1].ToString());
                    }
                }
            }

            Data = dic;
        }

        public void Dispose()
        {
            _changeTokenRegistration?.Dispose();
            _source.SqlServerWatcher?.Dispose();
        }
    }
}
