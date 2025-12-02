using System.Text.Json.Serialization;

namespace AdvAsmPlanning.Application.Constants;

/// <summary>
/// Available keys for dropdown values. Using an enum ensures Swagger shows allowed values as a dropdown.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DropdownKey
{
    AccountName = 1,
    AccountExternalReport,
    AccountGroup,
    AccountSubGroup,
    BusinessUnit,
    Division,
    Market
}
