using Application.DTOs;
using System.Net.Http.Json;
using static Client.Constants.ApiRoutes;

namespace Client.Services;

public class SaleService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ASMClient");
    public async Task<IEnumerable<SaleDto>> GetSalesStatsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<SaleDto>>(GetAllSales) ?? [];
    }
}
