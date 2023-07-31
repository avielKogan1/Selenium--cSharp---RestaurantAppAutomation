using RestSharp;

public class DashboardPageAPI
{
    private RestClient _client;
    private readonly string baseUrl = "http://localhost:8080/";


    public DashboardPageAPI()
    {
        _client = new RestClient("http://localhost:8080/");
    }

    // Define a method for getting the dashboard page.
    public RestResponse GetDashboardPage()
    {
        string requestRoute = "";
        var request = new RestRequest(requestRoute, Method.Get);
        Console.WriteLine($"GET request sent to : {baseUrl + requestRoute}");
        var response = _client.Execute(request);
        return response;
    }

    // Define a method for getting the top restaurants.
    public RestResponse GetTopRestaurantsDefault()
    {
        string requestRoute = "restaurants";
        var request = new RestRequest(requestRoute, Method.Get);
        Console.WriteLine($"GET request sent to : {baseUrl + requestRoute}");
        var response = _client.Execute(request);
        return response;
    }

    // ... Define other methods here...
}
