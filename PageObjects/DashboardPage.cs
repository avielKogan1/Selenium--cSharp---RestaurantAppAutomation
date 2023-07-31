using System;
using System.Net.NetworkInformation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class DashboardPage
{
    private IWebDriver _webDriver;

    // Define page url
    private readonly string url = "http://localhost:8080/";

    // Define web elements.

    private IWebElement topRestaurantsTitle => _webDriver.FindElement(By.Id("topRestaurantTitle"));
    private IWebElement numRestaurantsInputField => _webDriver.FindElement(By.Id("numRestaurants"));
    private IWebElement submitRestaurantsFormButton => _webDriver.FindElement(By.Id("submitRestaurantsFormButton"));
    private IWebElement topRestaurantsStatusElement => _webDriver.FindElement(By.Id("topRestaurantsStatus"));
    private IWebElement topRestaurantsList => _webDriver.FindElement(By.CssSelector("#topRestaurantsList"));

    private IWebElement restaurantNameInputField => _webDriver.FindElement(By.Id("restaurantName"));
    private IWebElement newCuisineInputField => _webDriver.FindElement(By.Id("newCuisine"));
    private IWebElement submitChangeCuisineFormButton => _webDriver.FindElement(By.Id("submitChangeCuisineFormButton"));
    private IWebElement changeCuisineStatusElement => _webDriver.FindElement(By.Id("changeCuisineStatus"));

    private IWebElement scoreToAddInputField => _webDriver.FindElement(By.Id("scoreToAdd"));
    private IWebElement limitInputField => _webDriver.FindElement(By.Id("limit"));
    private IWebElement submitAddScoreFormButton => _webDriver.FindElement(By.Id("submitAddScoreForm"));
    private IWebElement addScoreStatusElement => _webDriver.FindElement(By.Id("addScoreStatus"));

    // Define status messages
    private string topRestaurantsSuccessStatusText = "Status: OK";
    private string addScoresSuccessStatusText = "Status: Scores updated successfully";




    public DashboardPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public string getUrl()
    {
        return url;
    }

    public void Goto()
    {
        _webDriver.Navigate().GoToUrl(url);
        Console.WriteLine("Navigated to: " + url);
    }


    public void VerifyPageLoaded()
    {
        var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
        Console.WriteLine("Wait for page loaded set");
        // Add elements you want to check here
        try
        {
            wait.Until(driver => topRestaurantsTitle.Displayed);
            Console.WriteLine("Dashboard page loaded");
        }
        catch (WebDriverTimeoutException)
        {
            throw new Exception("topRestaurantsTitle is not visible after waiting for 15 seconds.");
        }
    }

    public void EnterNumRestaurants(int num)
    {
        var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
        Console.WriteLine("Wait set");

        try
        {
            wait.Until(driver => numRestaurantsInputField.Displayed);
            Console.WriteLine("Input Field visible");
            numRestaurantsInputField.Clear();
            numRestaurantsInputField.SendKeys(num.ToString());
            Console.WriteLine($"Input {num} restaurants");
        }
        catch
        {
            throw new Exception("numRestaurantsInputField is not visible after waiting for 15 seconds.");
        }
    }



    // Method to submit the top restaurants form.
    public void SubmitTopRestaurantsForm()
    {
        var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
        Console.WriteLine("Wait for submit button set");

        try
        {
            wait.Until(driver => submitRestaurantsFormButton.Displayed);
            Console.WriteLine("Submit Button visible");
            submitRestaurantsFormButton.Click();
            Console.WriteLine("Submit button clicked");
        }
        catch
        {
            throw new Exception("numRestaurantsInputField is not visible after waiting for 15 seconds.");
        }
        
    }

    // Method to verify the displayed list has the expected length.
    public void VerifyDisplayedList(int expectedLength)
    {
        Console.WriteLine($"Waiting for {expectedLength} elements list to be displayed");
        try
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver => topRestaurantsList.FindElements(By.TagName("li")).Count == expectedLength);

            IReadOnlyCollection<IWebElement> restaurantItems = topRestaurantsList.FindElements(By.TagName("li"));
            int actualLength = restaurantItems.Count;
            Assert.AreEqual(expectedLength, actualLength, $"Expected {expectedLength} items in the list, but found {actualLength}");
            Console.WriteLine($"{expectedLength} elements/restaurants list is displayed");
        }
        catch (WebDriverTimeoutException)
        {
            throw new AssertionException("Restaurant list did not become visible within 10 seconds.");
        }
    }


    // Similar methods for the other forms and actions.
}
