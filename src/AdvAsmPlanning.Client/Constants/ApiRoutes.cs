namespace AdvAsmPlanning.Client.Constants;

public static class ApiRoutes
{
    public const string GetAllForecasts = "Forecast/GetAll";
    public const string GetForecastById = "Forecast/GetById";
    public const string CreateForecast = "Forecast/Create";
    public const string UpdateForecast = "Forecast/Update";
    public const string DeleteForecast = "Forecast/Delete";

    public const string GetAllPlanningScenarios = "PlanningScenario/GetAll";
    public const string GetPlanningScenarioById = "PlanningScenario/GetById";
    public const string CreatePlanningScenario = "PlanningScenario/Create";
    public const string UpdatePlanningScenario = "PlanningScenario/Update";
    public const string DeletePlanningScenario = "PlanningScenario/Delete";
    
    public const string GetDropdownByKey = "Dropdown?key={0}";
}
