using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackAssist.Data.Factories;
using TrackAssist.Shared.ViewModels;
using TrackAssist.ViewModels;

namespace TrackAssistTests.Data.Factories
{
    [TestClass]
    public class BasicFilterFactoryTests
    {
        public BasicFilterFactory Factory { get; set; }
        public List<CaseViewModel> Cases { get; set; }
            
        [TestInitialize]
        public void Initialize()
        {
            Factory = new BasicFilterFactory();
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

        /*
        [TestMethod]
        [TestCategory("Unit")]
        public void WhenInvoked_ReturnedFuncFiltersProperly()
        {
            var usersViewModel = new UserListViewModel
            {
                AllUsers = new List<UserViewModel>
                {
                    GenerateUser("Tony", 1, false),
                    GenerateUser("Carly", 2, true)
                }
            };
            var func = Factory.GetFilterFunction<CaseViewModel, UserListViewModel>(usersViewModel,
                uvm => uvm.SelectedUsers.Select(u => u.Name), c => c.AssignedTo);

            var filteredCases = func(Cases);
            Assert.AreEqual(3, filteredCases.Count());
            Assert.IsTrue(filteredCases.Any(c => c.Number == 3));
            Assert.IsTrue(filteredCases.Any(c => c.Number == 4));
            Assert.IsTrue(filteredCases.Any(c => c.Number == 5));
        }
        */
        private UserViewModel GenerateUser(string name, int id, bool isSelected)
        {
            return new UserViewModel
            {
                Id = id,
                Name = name,
                IsSelected = isSelected
            };
        }
    }
}
