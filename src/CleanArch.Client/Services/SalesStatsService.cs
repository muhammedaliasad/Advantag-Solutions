using System.Net.Http.Json;
using CleanArch.Client.DTOs;
using static CleanArch.Client.Constants.ApiRoutes;

namespace CleanArch.Client.Services;

public class SalesStatsService(HttpClient httpClient)
{
    public async Task<IEnumerable<SalesStatDto>> GetSalesStatsAsync()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<SalesStatDto>>(SalesStats) ?? [];
    }
}
