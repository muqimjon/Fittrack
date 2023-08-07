namespace FTS.Service.DTOs;

public class WorkOutUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public int RestTime { get; set; }
    public string TargetMuscleGroups { get; set; } = string.Empty;

    public long UserId { get; set; }
}
