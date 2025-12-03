namespace AdvAsmPlanning.Application.DTOs;

public class MainGridDto
{
    public long Id { get; set; }
    public string Client { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string SizeProject { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string GoFind { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int? Delta { get; set; }
    public string AccountNo { get; set; } = string.Empty;
    public string DepartmentNo { get; set; } = string.Empty;

    public List<MainGridActualDto> Actuals { get; set; } = new();
}

public class MainGridActualDto
{
    public long Id { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Amount { get; set; }
}
