using System.Linq.Expressions;

namespace AdvAsmPlanning.Client.Helper;

/// <summary>
/// Helper class for filter operations
/// Implements DRY principle by centralizing filter logic
/// </summary>
public static class FilterHelper
{
    /// <summary>
    /// Applies a string filter to a query if the filter value is not empty
    /// </summary>
    public static IQueryable<T> ApplyStringFilter<T>(
        IQueryable<T> query,
        string? filterValue,
        Expression<Func<T, string>> propertySelector,
        bool caseSensitive = false)
    {
        if (string.IsNullOrWhiteSpace(filterValue))
            return query;

        var comparison = caseSensitive
            ? StringComparison.Ordinal
            : StringComparison.OrdinalIgnoreCase;

        var parameter = propertySelector.Parameters[0];
        var property = propertySelector.Body;
        var constant = Expression.Constant(filterValue);
        var containsMethod = typeof(string).GetMethod(
            nameof(string.Contains),
            new[] { typeof(string), typeof(StringComparison) })!;
        var containsCall = Expression.Call(property, containsMethod, constant, Expression.Constant(comparison));
        var lambda = Expression.Lambda<Func<T, bool>>(containsCall, parameter);

        return query.Where(lambda);
    }

    /// <summary>
    /// Applies an equality filter to a query if the filter value is not null
    /// </summary>
    public static IQueryable<T> ApplyEqualityFilter<T, TValue>(
        IQueryable<T> query,
        TValue? filterValue,
        Expression<Func<T, TValue>> propertySelector)
        where TValue : struct, IEquatable<TValue>
    {
        if (!filterValue.HasValue)
            return query;

        var parameter = propertySelector.Parameters[0];
        var property = propertySelector.Body;
        var constant = Expression.Constant(filterValue.Value, typeof(TValue));
        var equals = Expression.Equal(property, constant);
        var lambda = Expression.Lambda<Func<T, bool>>(equals, parameter);

        return query.Where(lambda);
    }
}

