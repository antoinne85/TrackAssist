using System;

namespace TrackAssist.Shared.ViewModels
{
    public class IntervalViewModel
    {
        public string Username { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Length { get { return (EndDate - StartDate).TotalHours; } }
    }
}