using System;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    internal class SqlServerPeriodicalWatcher : ISqlServerWatcher
    {
        private readonly TimeSpan _refreshInterval;
        private IChangeToken _changeToken;
        private readonly Timer _timer;
        private CancellationTokenSource _cancellationTokenSource;

        public SqlServerPeriodicalWatcher(TimeSpan refreshInterval)
        {
            _refreshInterval = refreshInterval;
            _timer = new Timer(Change, null, TimeSpan.Zero, _refreshInterval);
        }

        private void Change(object state)
        {
            _cancellationTokenSource?.Cancel();
        }

        public IChangeToken Watch()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _changeToken =  new CancellationChangeToken(_cancellationTokenSource.Token);

            return _changeToken;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _cancellationTokenSource?.Dispose();
        }
    }
}
