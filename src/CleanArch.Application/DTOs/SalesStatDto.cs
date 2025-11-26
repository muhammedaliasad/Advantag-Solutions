namespace CleanArch.Application.DTOs;

public class SalesStatDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public int TransactionCount { get; set; }
}
