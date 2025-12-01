using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AdvAsmPlanning.Client.Helper;

public class HttpHelper(IHttpClientFactory clientFactory, IJSRuntime jsRuntime)
{
    private readonly HttpClient _httpClient = clientFactory.CreateClient("ASMClient");

    // Method to retrieve token from the browser cookie using JS interop
    private async Task<string> GetTokenFromCookieAsync()
        => await jsRuntime.InvokeAsync<string>("cookieHelper.getCookie", "auth_token");

    // Method to send a POST request and deserialize to T
    public async Task<TResult?> PostAsync<TResult>(string url, object? payload = null)
    {
        var requestMessage = await CreateRequestMessageAsync(url, HttpMethod.Post, payload);
        var response = await _httpClient.SendAsync(requestMessage);
        return await HandleResponse<TResult>(response);
    }

    // Generic POST that distinguishes payload and result types
    public async Task<TResult?> PostAsync<TPayload, TResult>(string url, TPayload? content = default)
    {
        try
        {
            var requestMessage = await CreateRequestMessageAsync(url, HttpMethod.Post, content);
            var response = await _httpClient.SendAsync(requestMessage);
            return await HandleResponse<TResult>(response);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    // Helper method to create the HTTP request message
    private async Task<HttpRequestMessage> CreateRequestMessageAsync(string url, HttpMethod method, object? content = null)
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(url, UriKind.RelativeOrAbsolute),
            Method = method
        };

        // Add Bearer token to the Authorization header if a token is found
        // Implement later
        var token = string.Empty; // await GetTokenFromCookieAsync();
        if (!string.IsNullOrEmpty(token))
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Add the request content if provided (for POST, PUT requests)
        if (content != null && (method == HttpMethod.Post || method == HttpMethod.Put))
            requestMessage.Content = JsonContent.Create(content);

        return requestMessage;
    }

    // Helper method to handle the response and deserialize it
    private static async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<T>();
        if (result is null)
        {
            // If T is a value type return default value, otherwise return null
            if (typeof(T).IsValueType)
                return default;
            return default;
        }

        return result;
    }
}
