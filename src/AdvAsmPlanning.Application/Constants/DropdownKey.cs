namespace AdvAsmPlanning.Application.Constants;

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
