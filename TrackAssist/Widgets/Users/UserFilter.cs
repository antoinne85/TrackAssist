using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FogBugzApiWrapper;
using TrackAssist.Contracts;
using TrackAssist.Contracts.Data;
using TrackAssist.Contracts.Plugins;
using TrackAssist.Data.Factories;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;

namespace TrackAssist.Widgets.Users
{
    public class UserFilter : IPluggableUi, IRegisterableFilterSource, IConfigurable<UserFilterConfiguration>
    {
        private IFogBugzApi _api;
        
        public string Name { get { return "Users"; } }
        public Guid Identifier { get { return new Guid("4F24B3B3-207D-4E86-8D76-A3D0B757D6E5"); } }
        public FrameworkElement UiElement { get; private set; }        
        private UserFilterViewModel ViewModel { get; set; }

        public void RegistrationCallback(IFogBugzApi api)
        {
            _api = api;
            UiElement = new UserFilterWidget();
            ViewModel = new UserFilterViewModel(_api);
            UiElement.DataContext = ViewModel;
        }

        public Func<IEnumerable<CaseViewModel>, IEnumerable<CaseViewModel>> GetCaseFilterFunction(IBasicFilterFactory filterFactory)
        {
            if (!ViewModel.FilteringEnabled)
            {
                return null;
            }
            return filterFactory.GetFilterFunction<CaseViewModel, UserFilterViewModel>(ViewModel,
                ul => ul.SelectedUsers.Select(u => u.Name), c => c.AssignedTo);
        }

        public Func<IEnumerable<IntervalViewModel>, IEnumerable<IntervalViewModel>> GetIntervalFilterFunction(IBasicFilterFactory filterFactory)
        {
            if (!ViewModel.FilteringEnabled)
            {
                return null;
            }
            return filterFactory.GetFilterFunction<IntervalViewModel, UserFilterViewModel>(ViewModel,
                ul => ul.SelectedUsers.Select(u => u.Name), c => c.Username);
        }

        public void ApplyConfiguration(object config)
        {
            var tConfig = config as UserFilterConfiguration;
            var usersToSelect = ViewModel.AllUsers.Where(u => tConfig.SelectedUserIds.Contains(u.Id));
            foreach (var user in usersToSelect)
            {
                user.IsSelected = true;
            }
            ViewModel.FilteringEnabled = tConfig.FilteringEnabled;
        }

        object IConfigurable.GetConfiguration()
        {
            return new UserFilterConfiguration
            {
                SelectedUserIds = ViewModel.SelectedUsers.Select(u => u.Id).ToList(),
                FilteringEnabled = ViewModel.FilteringEnabled
            };
        }
    }
}