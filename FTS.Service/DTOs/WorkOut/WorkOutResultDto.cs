using FTS.Domain.Entities;

namespace FTS.Service.DTOs;

public class WorkOutResultDto
{
    public string Name { get; set; } = string.Empty;
    public string Meals { get; set; } = string.Empty;
    public int CaloricGoal { get; set; }
    public int MyProperty { get; set; }
    public string MacronutrientDistribution { get; set; } = string.Empty;

    public User User { get; set; } = default!;
}
