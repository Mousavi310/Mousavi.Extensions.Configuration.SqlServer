using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerConfigurationSource : IConfigurationSource
    {
        public string ConnectionString { get; set; }
        public string Schema { get; set; } = "config";
        public string Table { get; set; } = "Settings";
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlServerConfigurationProvider(this);
        }
    }
}
