using System.Windows;
using FogBugzApiWrapper;

namespace TrackAssist.Contracts.Plugins
{
    public interface IPluggableUi : IPluggable
    {
        string Name { get; }
        FrameworkElement UiElement { get; }
        void RegistrationCallback(IFogBugzApi api);
    }
}