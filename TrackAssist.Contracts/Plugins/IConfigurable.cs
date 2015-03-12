namespace TrackAssist.Contracts.Plugins
{
    public interface IConfigurable : IPluggable
    {
        object GetConfiguration();
        void ApplyConfiguration(object config);        
    }

    public interface IConfigurable<T> : IConfigurable
    {

    }
}