
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
    public ApiClient(HttpClient httpClient, IOptions<HttpClientOptions> httpClientOptions)
    {
        _httpClient = httpClient;
        _httpClientOptions = httpClientOptions.Value;
    }

    public async Task<HttpResponseMessage> Post(string requestModel, string uri)
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(uri),
            Method = HttpMethod.Post,
            Content = new StringContent(requestModel, null, _httpClientOptions.Accept)
        };


        return await _httpClient.SendAsync(requestMessage);
    }

    public async Task<HttpResponseMessage> Get(string uri)
    {
        return await _httpClient.GetAsync(uri);
    }
}
