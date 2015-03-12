using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackAssist.Data.Factories;
using TrackAssist.ViewModels;

namespace TrackAssistTests.Data.Factories
{
    [TestClass]
    public class GenericDataSeriesFactoryTests
    {
        private GenericDataSeriesFactory Factory { get; set; }
        private List<CaseViewModel> Cases { get; set; }
            
        [TestInitialize]
        public void Initialize()
        {
            Factory = new GenericDataSeriesFactory(new DataPointFactory());
            Cases = new List<CaseViewModel>
            {
                GenerateCase("Tony", "A", 1),
                GenerateCase("Tony", "B", 2),
                GenerateCase("Carly", "A", 3),
                GenerateCase("Carly", "B", 4),
                GenerateCase("Carly", "A", 5)
            };
        }

        private CaseViewModel GenerateCase(string assignedTo, string milestone, int number)
        {
            return new CaseViewModel
            {
                AssignedTo = assignedTo,
                Milestone = milestone,
                Number = number,
                Title = string.Format("Case{0}", number)
            };
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void WhenGivenData_GroupsByCategorySelector()
        {
            var generatedSeries = Factory.Create(Cases, c => c.AssignedTo, c => c.Number);
            Assert.AreEqual(2, generatedSeries.DataPoints.Count, "More or fewer data points were generated than expected.");
            
            var categories = generatedSeries.DataPoints.Select(dp => dp.Category);
            Assert.IsTrue(categories.Contains("Tony"));
            Assert.IsTrue(categories.Contains("Carly"));
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void WhenGivenData_AndUsingSumAggregation_AggregatesCorrectly()
        {
            var generatedSeries = Factory.Create(Cases, c => c.AssignedTo, c => c.Number, ValueAggregationMode.Sum);
            var tonysCases = generatedSeries.DataPoints.FirstOrDefault(dp => dp.Category == "Tony");
            var carlysCases = generatedSeries.DataPoints.FirstOrDefault(dp => dp.Category == "Carly");
            Assert.AreEqual(3, tonysCases.Value);
            Assert.AreEqual(12, carlysCases.Value);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void WhenGivenData_AndUsingAverageAggregation_AggregatesCorrectly()
        {
            var generatedSeries = Factory.Create(Cases, c => c.AssignedTo, c => c.Number, ValueAggregationMode.Average);
            var tonysCases = generatedSeries.DataPoints.FirstOrDefault(dp => dp.Category == "Tony");
            var carlysCases = generatedSeries.DataPoints.FirstOrDefault(dp => dp.Category == "Carly");
            Assert.AreEqual(1.5, tonysCases.Value);
            Assert.AreEqual(4, carlysCases.Value);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void WhenGivenData_AndUsingPercentOfWholeAggregation_AggregatesCorrectly()
        {
            var generatedSeries = Factory.Create(Cases, c => c.AssignedTo, c => c.Number, ValueAggregationMode.PercentOfWhole);
            var tonysCases = generatedSeries.DataPoints.FirstOrDefault(dp => dp.Category == "Tony");
            var carlysCases = generatedSeries.DataPoints.FirstOrDefault(dp => dp.Category == "Carly");
            Assert.AreEqual(1/5.0, tonysCases.Value);
            Assert.AreEqual(4/5.0, carlysCases.Value);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void WhenGivenPropertySelectors_GeneratesCorrectChartName()
        {
            var generatedSeries = Factory.Create(Cases, c => c.AssignedTo, c => c.Number);
            Assert.AreEqual("Case Number by Assigned To User", generatedSeries.Title);
        }
    }
}
