using AdvAsmPlanning.Application;
using AdvAsmPlanning.Client.Helper;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace AdvAsmPlanning.Client.Pages.Base;

/// <summary>
/// Base class for grid pages providing common functionality
/// Implements DRY principle by centralizing shared grid operations
/// </summary>
public abstract class BaseGridPage<TDto> : ComponentBase
    where TDto : class
{
    [Inject] protected HttpHelper HttpHelper { get; set; } = null!;
    [Inject] protected NotificationService NotificationService { get; set; } = null!;
    [Inject] protected DialogService DialogService { get; set; } = null!;

    protected RadzenDataGrid<TDto>? Grid { get; set; }
    protected bool IsLoading { get; set; }

    /// <summary>
    /// Shows a notification message to the user
    /// </summary>
    protected void ShowNotification(string title, string message, NotificationSeverity severity)
    {
        NotificationService.Notify(new NotificationMessage
        {
            Severity = severity,
            Summary = title,
            Detail = message,
            Duration = 4000
        });
    }

    /// <summary>
    /// Shows a success notification
    /// </summary>
    protected void ShowSuccess(string message) => ShowNotification("Success", message, NotificationSeverity.Success);

    /// <summary>
    /// Shows an error notification
    /// </summary>
    protected void ShowError(string message) => ShowNotification("Error", message, NotificationSeverity.Error);

    /// <summary>
    /// Shows an info notification
    /// </summary>
    protected void ShowInfo(string message) => ShowNotification("Info", message, NotificationSeverity.Info);

    /// <summary>
    /// Handles exceptions with proper error notification
    /// </summary>
    protected void HandleException(Exception ex, string operation)
    {
        ShowError($"An error occurred during {operation}: {ex.Message}");
    }

    /// <summary>
    /// Confirms an action with the user
    /// </summary>
    protected async Task<bool> ConfirmActionAsync(string message, string title = "Confirm")
    {
        var result = await DialogService.Confirm(
            message,
            title,
            new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });
        return result == true;
    }
}

