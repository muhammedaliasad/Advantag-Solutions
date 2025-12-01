namespace AdvAsmPlanning.Domain.Entities;

public class Forecast : BaseEntity
{
    public Forecast()
    {
        Actuals = new List<ForecastActual>();
    }

    public string Client { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string SizeProject { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string GoFind { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int? Delta { get; set; }
    public string AccountNo { get; set; } = string.Empty;
    public string DepartmentNo { get; set; } = string.Empty;

    public virtual ICollection<ForecastActual> Actuals { get; set; }
}
