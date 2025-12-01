namespace AdvAsmPlanning.Client.Models;

public class DropdownDto
{
    public long Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public long? ParentId { get; set; }
}

