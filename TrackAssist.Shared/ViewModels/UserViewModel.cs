using PostSharp.Patterns.Model;
namespace TrackAssist.Shared.ViewModels
{

    [NotifyPropertyChanged]
    public class UserViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSelected { get; set; }
    }
}