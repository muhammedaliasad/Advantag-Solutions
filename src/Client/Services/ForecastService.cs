using Application.DTOs;
using System.Net.Http.Json;
using static Client.Constants.ApiRoutes;

namespace Client.Services;

public class ForecastService
{
    private readonly HttpClient _httpClient;

    public ForecastService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ASMClient");
    }

    public async Task<List<ForecastDto>> GetForecastsAsync()
    {
        try
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<ForecastDto>>(GetAllForecasts);
            return forecasts ?? new List<ForecastDto>();
        }
        catch (HttpRequestException ex)
        {
            // Log error or handle as needed
            Console.WriteLine($"Error fetching forecasts: {ex.Message}");
            return new List<ForecastDto>();
        }
    }

    public async Task<ForecastDto?> GetForecastByIdAsync(long id)
    {
        return await _httpClient.GetFromJsonAsync<ForecastDto>(string.Format(GetForecastById, id));
    }

    public async Task<ForecastDto?> CreateForecastAsync(ForecastDto forecast)
    {
        var response = await _httpClient.PostAsJsonAsync(CreateForecast, forecast);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ForecastDto>();
    }

    public async Task<ForecastDto?> UpdateForecastAsync(long id, ForecastDto forecast)
    {
        var response = await _httpClient.PutAsJsonAsync(string.Format(UpdateForecast, id), forecast);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ForecastDto>();
    }

    public async Task<bool> DeleteForecastAsync(long id)
    {
        var response = await _httpClient.DeleteAsync(string.Format(DeleteForecast, id));
        return response.IsSuccessStatusCode;
    }
}
