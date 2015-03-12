using System;
using System.Collections.Generic;
using System.Linq;
using FogBugzApiWrapper;
using TrackAssist.ViewModels;

namespace TrackAssist.Widgets.Milestones
{
    public class MilestonesFilterViewModel
    {
        private readonly IFogBugzApi _api;

        public MilestonesFilterViewModel(IFogBugzApi api)
        {
            if (api == null)
            {
                throw new ArgumentNullException("api");
            }

            _api = api;

            Initialize();
        }

        public List<MilestoneViewModel> AllMilestones { get; set; }

        public IEnumerable<MilestoneViewModel> SelectedMilestones
        {
            get { return AllMilestones.Where(m => m.IsSelected); }
        }

        private void Initialize()
        {
            AllMilestones = _api.ListMilestones().Select(m => new MilestoneViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();
        }
    }
}