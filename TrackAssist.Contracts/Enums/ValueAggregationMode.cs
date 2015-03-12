using System.ComponentModel.DataAnnotations;

namespace TrackAssist.Contracts.Enums
{
    public enum ValueAggregationMode
    {
        [Display(Name="Sum")]
        Sum,
        [Display(Name="Average")]
        Average,
        [Display(Name="Percent of Whole")]
        PercentOfWhole
    }
}