using FTS.Domain.Entities;

namespace FTS.Service.DTOs;

public class NuritionPlanResultDto
{
    public long Id { get; set; }
    public string Name { get; } = string.Empty;
    public string Meals { get; } = string.Empty;
    public int CaloricGoal { get; }
    public string MacronutrientDistribution { get; } = string.Empty;

    public User User { get; } = default!;
}
