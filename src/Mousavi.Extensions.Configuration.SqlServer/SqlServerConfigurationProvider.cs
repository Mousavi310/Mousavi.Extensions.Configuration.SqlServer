using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerConfigurationProvider : ConfigurationProvider
    {
        private readonly SqlServerConfigurationSource _source;
        private readonly string _query;

        public SqlServerConfigurationProvider(SqlServerConfigurationSource source)
        {
            _source = source;
            _query =$"select [Name], [Value] from {_source.Schema}.{_source.Table}";
            
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
    }
}
