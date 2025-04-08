using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;


public class WeatherService
{
    private const string ApiKey = "0608319f1864642730796423be649686";
    private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather";

    private readonly HttpClient _client;

    public WeatherService()
    {
        _client = new HttpClient();
    }

    public async Task<WeatherData?> GetWeatherAsync(string city)
    {
        try
        {
            //HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}?q={city}&lang=pl&appid={ApiKey}&units=metric");
            HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            WeatherData? weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

            return weatherData;
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");
            // Obsługa błędu HTTP
            Debug.WriteLine($"Błąd podczas pobierania danych: {ex.Message}");
            return null;
        }
    }
}


public class WeatherData
{
    [JsonProperty("main")]
    public MainData? Main { get; set; }

    [JsonProperty("weather")]
    public WeatherInfo[]? Weather { get; set; }
}

public class MainData
{
    [JsonProperty("temp")]
    public float Temperature { get; set; }

    [JsonProperty("humidity")]
    public float Humidity { get; set; }

    [JsonProperty("pressure")]
    public float Pressure { get; set; }
}

public class WeatherInfo
{
    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("icon")]
    public string? Icon { get; set; }
}
