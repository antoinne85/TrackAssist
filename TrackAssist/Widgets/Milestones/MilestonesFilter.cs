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

namespace TrackAssist.Widgets.Milestones
{
    public class MilestonesFilter : IPluggableUi, IRegisterableFilterSource
    {
        private IFogBugzApi _api;
        public string Name { get { return "Milestones"; }}
        public FrameworkElement UiElement { get; private set; }
        private MilestonesFilterViewModel RealViewModel { get; set; }
        public void RegistrationCallback(IFogBugzApi api)
        {
            _api = api;
            UiElement = new MilestonesFilterWidget();
            RealViewModel = new MilestonesFilterViewModel(_api);
            UiElement.DataContext = RealViewModel;
        }

        public Guid Identifier { get; private set; }
        public Func<IEnumerable<CaseViewModel>, IEnumerable<CaseViewModel>> GetCaseFilterFunction(IBasicFilterFactory filterFactory)
        {
            return filterFactory.GetFilterFunction<CaseViewModel, MilestonesFilterViewModel>(RealViewModel,
                ul => ul.SelectedMilestones.Select(u => u.Name), c => c.Milestone);
        }

        public Func<IEnumerable<IntervalViewModel>, IEnumerable<IntervalViewModel>> GetIntervalFilterFunction(IBasicFilterFactory filterFactory)
        {
            return null;
        }
    }
}
