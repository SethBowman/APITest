using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

// Grab appsettings file
var apiKeyObj = File.ReadAllText("appsettings.json");
// Get the api key from the appsettings file using the key "apiKey"
var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

// Enter the zip for which you want to retrieve the weather forecast
string zipCode = "35091";

// Build the API URL using the provided zip and API key
string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";

// Create HTTPClient - This is what actually makes the API call
var client = new HttpClient();

// API Call - This will return a JSON Object formatted as a string
var response = client.GetStringAsync(apiUrl).Result;

// Parse string as a JSON Object - This obj can be indexed like an array
var weatherObj = JObject.Parse(response);

// Print the information we need - Use weather object and index the properties needed
Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");


