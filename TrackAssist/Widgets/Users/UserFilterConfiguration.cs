using System.Collections.Generic;

namespace TrackAssist.Widgets.Users
{
    public class UserFilterConfiguration
    {
        public List<int> SelectedUserIds { get; set; }
        public bool FilteringEnabled { get; set; }

        public UserFilterConfiguration()
        {
            SelectedUserIds = new List<int>();
        }
    }
}