
using CalorieTracker.Application.Contracts.HttpClientService;
using CalorieTracker.Application.Options.ApiClient;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace CalorieTracker.Application.HttpClientService;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;
    private readonly HttpClientOptions _httpClientOptions;
    public HttpRequestMessage RequestMessage { get; set; } = new HttpRequestMessage();
    public ApiClient(HttpClient httpClient, IOptions<HttpClientOptions> httpClientOptions)
    {
        _httpClient = httpClient;
        _httpClientOptions = httpClientOptions.Value;
    }

    public async Task<HttpResponseMessage> Post(string requestModel, string uri)
    {
        RequestMessage.RequestUri = new Uri(uri);
        RequestMessage.Method = HttpMethod.Post;
        RequestMessage.Content = new StringContent(requestModel, null, _httpClientOptions.Accept);

        var body = await RequestMessage.Content.ReadAsStringAsync();
        Console.WriteLine(body);

        return await _httpClient.SendAsync(RequestMessage);
    }

    public async Task<HttpResponseMessage> Get(string uri)
    {
        return await _httpClient.GetAsync(uri);
    }
}
