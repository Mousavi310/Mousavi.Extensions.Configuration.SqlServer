using Microsoft.Extensions.Configuration;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerConfigurationSource : IConfigurationSource
    {
        public string ConnectionString { get; set; }
        public string Schema { get; set; } = "dbo";
        public string Table { get; set; } = "Settings";
        public string KeyColumn { get; set; } = "[Key]";
        public string ValueColumn { get; set; } = "[Value]";
        internal ISqlServerWatcher SqlServerWatcher { get; set; } 

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlServerConfigurationProvider(this);
        }
    }
}
