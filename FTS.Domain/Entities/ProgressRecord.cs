using FTS.Domain.Commons;

namespace FTS.Domain.Entities;

public class ProgressRecord : AudiTable
{
    public DateTime Date { get; set; }
    public int WeightMeasurements { get; set; }
    public string BodyMeasurements { get; set; } = string.Empty;
    public string FitnessRecords { get; set; } = string.Empty;

    public long UserId { get; set; }
    public User User { get; set; } = default!;
}
