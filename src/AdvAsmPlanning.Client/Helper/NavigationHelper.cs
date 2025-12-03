using Microsoft.AspNetCore.Components;

namespace AdvAsmPlanning.Client.Helper;

public static class NavigationHelper
{
    /// <summary>
    /// Parses query string parameters from the current navigation URI
    /// </summary>
    public static Dictionary<string, string> ParseQueryParameters(NavigationManager navigationManager)
    {
        var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
        var queryParams = new Dictionary<string, string>();

        if (string.IsNullOrEmpty(uri.Query)) 
            return queryParams;

        var queryString = uri.Query.TrimStart('?');
        var pairs = queryString.Split('&', StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in pairs)
        {
            var parts = pair.Split('=', 2);
            if (parts.Length == 2)
            {
                var key = Uri.UnescapeDataString(parts[0]);
                var value = Uri.UnescapeDataString(parts[1]);
                queryParams[key] = value;
            }
        }

        return queryParams;
    }

    /// <summary>
    /// Gets a query parameter value by key
    /// </summary>
    public static string? GetQueryParameter(NavigationManager navigationManager, string key)
    {
        var queryParams = ParseQueryParameters(navigationManager);
        return queryParams.TryGetValue(key, out var value) ? value : null;
    }
}

