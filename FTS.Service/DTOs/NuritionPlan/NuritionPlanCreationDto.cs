namespace FTS.Service.DTOs;

public class NuritionPlanCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string Meals { get; set; } = string.Empty;
    public int CaloricGoal { get; set; }
    public string MacronutrientDistribution { get; set; } = string.Empty;

    public long UserId { get; set; }
}
