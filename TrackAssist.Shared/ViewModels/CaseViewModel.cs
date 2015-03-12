using System.ComponentModel.DataAnnotations;

namespace TrackAssist.Shared.ViewModels
{
    public class CaseViewModel
    {
        [Display(Name = "Assigned To User")]
        public string AssignedTo { get; set; }
        
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Milestone")]
        public string Milestone { get; set; }
        
        [Display(Name = "Case Number")]
        public int Number { get; set; }

        [Display(Name = "Estimated Time")]
        public double EstimatedTime { get; set; }

        [Display(Name = "Elapsed Time")]
        public double ElapsedTime { get; set; }
    }
}