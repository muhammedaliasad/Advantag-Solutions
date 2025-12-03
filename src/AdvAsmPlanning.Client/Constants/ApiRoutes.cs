namespace AdvAsmPlanning.Client.Constants;

public static class ApiRoutes
{
    public const string GetAllMainGrids = "MainGrid/GetAll";
    public const string GetMainGridById = "MainGrid/GetById";
    public const string CreateMainGrid = "MainGrid/Create";
    public const string UpdateMainGrid = "MainGrid/Update";
    public const string DeleteMainGrid = "MainGrid/Delete";

    public const string GetAllScenarios = "Scenario/GetAll";
    public const string GetScenarioById = "Scenario/GetById";
    public const string CreateScenario = "Scenario/Create";
    public const string UpdateScenario = "Scenario/Update";
    public const string DeleteScenario = "Scenario/Delete";

    public const string GetDropdownByKey = "Dropdown?key={0}";
}
