namespace CalorieTracker.Application.Contracts.HttpClientService;

public interface IApiClient
{
    Task<HttpResponseMessage> Post(string requestModel, string uri);
    Task<HttpResponseMessage> Get(string uri);
}
