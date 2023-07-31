using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace PracticeAutomation.Tests.Sanity
{
    [TestFixture]
    public class HomePageSanityTest
    {
        private IWebDriver _webDriver;
        private DashboardPage _dashboardPage;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _webDriver = new ChromeDriver("/Users/avielkogan/drivers/chromedriver");
            _dashboardPage = new DashboardPage(_webDriver);
        }



        [Test]
        public void GetRestaurantsWithTopValueTest()
        {
            int topRestaurants = 10;
            // Step 1: Navigate to the homepage.
            _dashboardPage.Goto();
            Console.WriteLine($"Navigated to {_dashboardPage.getUrl()}");


            // Step 2: Verify the page has loaded.
            _dashboardPage.VerifyPageLoaded();
            Console.WriteLine("Dashboard page loaded");

            _dashboardPage.EnterNumRestaurants(topRestaurants);
            Console.WriteLine($"Entered {topRestaurants} restaurants");

            _dashboardPage.SubmitTopRestaurantsForm();
            Console.WriteLine("Submitted form");

            _dashboardPage.VerifyDisplayedList(topRestaurants);
            Console.WriteLine("List verified");

            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _webDriver.Quit();
        }
    }
}
