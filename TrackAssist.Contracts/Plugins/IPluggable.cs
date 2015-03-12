using System;

namespace TrackAssist.Contracts.Plugins
{
    public interface IPluggable
    {
        Guid Identifier { get; }
    }
}