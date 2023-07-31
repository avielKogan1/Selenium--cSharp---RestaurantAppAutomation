using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;


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
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public void TestGetTopRestaurantsDefault()
        {
            int expectedLength = 10;
            var response = _dashboardPageAPI.GetTopRestaurantsDefault();
            Assert.AreEqual(200, (int)response.StatusCode);

            var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response.Content);
            Console.WriteLine(data);
            Console.WriteLine($"Response list lenght is {data.Count}");
            Assert.AreEqual(expectedLength, data.Count, $"Response list lenght is {data.Count}, instead of {expectedLength}");
        }


        //... rest of the test methods ...
    }
}
