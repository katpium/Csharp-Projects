using System.Diagnostics.Contracts;
using System.IO.Pipelines;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("api/cats", async () =>
{
    HttpClient client = new HttpClient();

    //To get more images from the API I need to use the API key! 
    //This is how to fetch it
        // -> For this I wont use that tho (public repo)
    //client.DefaultRequestHeaders.Add("x-api-key", USE_API_KEY_HERE);

    string url = "https://api.thecatapi.com/v1/images/search?limit=10";

    List<CatImage>? cats = await client.GetFromJsonAsync<List<CatImage>>(url);

    if(cats == null || cats.Count == 0)
    {
        return Result.NotFound("No cat image found.");
    }
});

app.Run();

public class CatImage
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("url")]
    public string Url { get; set; } = "";

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }
}