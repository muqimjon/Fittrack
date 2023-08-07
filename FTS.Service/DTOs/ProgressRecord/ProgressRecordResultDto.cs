using FTS.Domain.Entities;

namespace FTS.Service.DTOs;

public class ProgressRecordResultDto
{
    public long Id { get; }
    public DateTime Date { get; }
    public int WeightMeasurements { get; }
    public string BodyMeasurements { get; } = string.Empty;
    public string FitnessRecords { get; } = string.Empty;

    public User User { get; } = default!;
}
