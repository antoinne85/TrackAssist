using System;
using System.Collections.Generic;
using System.Linq;
using FogBugzApiWrapper;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;

namespace TrackAssist.Widgets.Users
{
    public class UserFilterViewModel
    {
        public bool FilteringEnabled { get; set; }
        public List<UserViewModel> AllUsers { get; set; }
        public IEnumerable<UserViewModel> SelectedUsers
        {
            get { return AllUsers.Where(u => u.IsSelected); }
        }

        public UserFilterViewModel(IFogBugzApi api)
        {
            if (api == null)
            {
                throw new ArgumentNullException("api");
            }

            AllUsers = AllUsers = api.ListUsers().Select(u => new UserViewModel
            {
                Name = u.Name,
                Id = u.Id
            }).ToList();
        }        
    }
}