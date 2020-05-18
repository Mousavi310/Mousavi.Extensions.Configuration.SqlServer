using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    public class SqlServerPeriodicalWatcher
    {
        private readonly SqlServerConfigurationSource _source;
        private IChangeToken _changeToken;
        private Timer _timer;
        private CancellationTokenSource _cancellationTokenSource;

        public SqlServerPeriodicalWatcher(SqlServerConfigurationSource source)
        {
            _source = source;
            _timer = new Timer(Check, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void Check(object state)
        {
            _cancellationTokenSource?.Cancel();
        }

        public IChangeToken Watch()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _changeToken =  new CancellationChangeToken(_cancellationTokenSource.Token);

            return _changeToken;
        }
    }
}
