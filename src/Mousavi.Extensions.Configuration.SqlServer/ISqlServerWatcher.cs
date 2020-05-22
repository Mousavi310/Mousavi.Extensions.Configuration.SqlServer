using System;
using Microsoft.Extensions.Primitives;

namespace Mousavi.Extensions.Configuration.SqlServer
{
    internal interface ISqlServerWatcher : IDisposable
    {
        IChangeToken Watch();
    }
}
