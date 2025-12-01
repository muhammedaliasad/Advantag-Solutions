namespace AdvAsmPlanning.Application;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<string>? Errors { get; set; }

    public long TotalRecords { get; set; }

    public static ApiResponse SuccessResponse(string message = "", long totalRecords = 0, long totalPages = 0)
        => new()
        {
            Success = true,
            Message = message ?? string.Empty,
            TotalRecords = totalRecords
        };

    public static ApiResponse FailureResponse(string message)
        => new()
        {
            Success = false,
            Message = message ?? string.Empty
        };
}

public class ApiResponseDto<T> : ApiResponse
{
    // Optional data of type T (supports nullable reference and value types)
    public T? Data { get; set; } = default!;

    // Convenience factory for success responses
    public static ApiResponseDto<T> SuccessResponse(T data = default, long totalRecords = 0, string message = "")
        => new()
        {
            Success = true,
            Data = data,
            TotalRecords = totalRecords,
            Message = message ?? string.Empty
        };

    // Convenience factory for failure responses
    public static new ApiResponseDto<T> FailureResponse(string message)
        => new()
        {
            Success = false,
            Message = message ?? string.Empty
        };
}