using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;


namespace ApiTest
{
    [TestFixture]
    public class ApiTests
    {
        private DashboardPageAPI _dashboardPageAPI;

        [SetUp]
        public void Setup()
        {
            _dashboardPageAPI = new DashboardPageAPI();
        }




        [Test]
        public void TestGetDashboardPage()
        {
            var response = _dashboardPageAPI.GetDashboardPage();
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void TestGetTopRestaurantsDefault()
        {
            int expectedLength = 10;
            Console.WriteLine($"Default top restaurants num is {expectedLength}");
            var response = _dashboardPageAPI.GetTopRestaurantsDefaultValue();
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Console.WriteLine($"Response status code is {response.StatusCode}");

            Assert.IsNotNull(response.Content, "Response content is null");


            var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response.Content);
            Assert.IsNotNull(data, "data is null");
            Console.WriteLine(data);
            Console.WriteLine($"Response list lenght is {data.Count}");
            Assert.That(data.Count, Is.EqualTo(expectedLength), $"Response list lenght is {data.Count}, instead of {expectedLength}");
        }


        [Test]
        public void TestGetTopRestaurants()
        {
            int topRestaurantsNum = 5;
            var response = _dashboardPageAPI.GetTopRestaurants(topRestaurantsNum);
            Console.WriteLine($"Default top restaurants num is {topRestaurantsNum}");
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Console.WriteLine($"Response status code is {response.StatusCode}");

            Assert.IsNotNull(response.Content, "Response content is null");


            var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response.Content);
            Assert.IsNotNull(data, "data is null");
            Console.WriteLine(data);
            Console.WriteLine($"Response list lenght is {data.Count}");
            Assert.That(data.Count, Is.EqualTo(topRestaurantsNum), $"Response list lenght is {data.Count}, instead of {topRestaurantsNum}");
        }


        [Test]
        public void TestChangeCuisine()
        {
            string restaurantName = "Happy Garden";
            string newCuisineName = "Mexican";

            var response = _dashboardPageAPI.PatchChangeCuisine(restaurantName, newCuisineName);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Console.WriteLine($"Response status code is {response.StatusCode}");

            Assert.IsNotNull(response.Content, "Response content is null");

            string responseContent = response.Content.ToString();
            Assert.IsTrue(responseContent.Contains($"Cuisine of restaurant {restaurantName} updated successfully"), "Response message is not displayed correctly");

            Console.WriteLine($"Response message is {responseContent}");
        }



    }
}
