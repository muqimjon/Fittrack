using FTS.Domain.Commons;

namespace FTS.Domain.Entities;

public class NuritionPlan : AudiTable
{
    public string Name { get; set; } = string.Empty;
    public string Meals { get; set; } = string.Empty;
    public int CaloricGoal { get; set; }
    public string MacronutrientDistribution { get; set; } = string.Empty;

    public long UserId { get; set; }
    public User User { get; set; } = default!;
}