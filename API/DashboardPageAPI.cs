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
    public RestResponse GetTopRestaurantsDefaultValue()
    {
        string requestRoute = "restaurants";
        var request = new RestRequest(requestRoute, Method.Get);
        Console.WriteLine($"GET request sent to : {baseUrl + requestRoute}");
        var response = _client.Execute(request);
        return response;
    }


    public RestResponse GetTopRestaurants(int top)
    {
        string requestRoute = "restaurants" + $"?top={top}";
        var request = new RestRequest(requestRoute, Method.Get);
        Console.WriteLine($"GET request sent to : {baseUrl + requestRoute}");
        var response = _client.Execute(request);
        return response;
    }


    public RestResponse PatchChangeCuisine(string restaurantName, string cuisineName)
    {
        string requestRoute = $"restaurants/{restaurantName}";
        var request = new RestRequest(requestRoute, Method.Patch);
        Console.WriteLine($"PATCH request sent to : {baseUrl + requestRoute}");
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new { cuisine = cuisineName });

        var response = _client.Execute(request);

        return response;
    }

}
