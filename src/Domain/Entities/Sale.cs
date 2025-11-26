namespace Domain.Entities;

public class Sale : BaseEntity
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
}
