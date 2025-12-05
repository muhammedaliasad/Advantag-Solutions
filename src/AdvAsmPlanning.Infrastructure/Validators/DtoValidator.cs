namespace AdvAsmPlanning.Infrastructure.Validators;

/// <summary>
/// Generic validator for DTOs used in services
/// Supports multiple validation types and can be extended for future validation needs
/// </summary>
public static class DtoValidator
{
    #region Id Validation

    /// <summary>
    /// Validates that an Id is greater than zero
    /// </summary>
    /// <typeparam name="T">The type of the DTO</typeparam>
    /// <param name="id">The Id to validate</param>
    /// <param name="logger">Logger instance for logging warnings</param>
    /// <param name="entityName">Optional entity name for logging context</param>
    /// <returns>Validation error message if invalid, null if valid</returns>
    public static string? ValidateId<T>(long id, ILogger logger, string? entityName = null)
    {
        if (id <= 0)
        {
            var entityContext = string.IsNullOrWhiteSpace(entityName) ? typeof(T).Name : entityName;
            logger.LogWarning("Invalid Id provided for {EntityType} update: {Id}", entityContext, id);
            return "Invalid Id. Id must be greater than zero.";
        }

        return null;
    }

    /// <summary>
    /// Validates that an Id is greater than zero and returns a failure response if invalid
    /// </summary>
    /// <typeparam name="TDto">The type of the DTO</typeparam>
    /// <param name="id">The Id to validate</param>
    /// <param name="logger">Logger instance for logging warnings</param>
    /// <param name="entityName">Optional entity name for logging context</param>
    /// <returns>Failure response if invalid, null if valid</returns>
    public static ApiResponseDto<TDto>? ValidateIdWithResponse<TDto>(long id, ILogger logger, string? entityName = null)
    {
        var errorMessage = ValidateId<TDto>(id, logger, entityName);
        if (errorMessage != null)
        {
            return ApiResponseDto<TDto>.FailureResponse(errorMessage);
        }

        return null;
    }

    #endregion

    // Future validation methods can be added here
    // Example:
    // #region String Validation
    // public static string? ValidateRequiredString(string? value, string fieldName, ILogger logger) { ... }
    // #endregion
}

