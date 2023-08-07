using FTS.Domain.Commons;

namespace FTS.Domain.Entities;

public class WorkOut : AudiTable
{
    public string Name { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public int RestTime { get; set; }
    public string TargetMuscleGroups { get; set; } = string.Empty;

    public long UserId { get; set; }
    public User User { get; set; } = default!;
}
