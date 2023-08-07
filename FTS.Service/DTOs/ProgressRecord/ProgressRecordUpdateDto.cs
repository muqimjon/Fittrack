namespace FTS.Service.DTOs;

public class ProgressRecordUpdateDto
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public int WeightMeasurements { get; set; }
    public string BodyMeasurements { get; set; } = string.Empty;
    public string FitnessRecords { get; set; } = string.Empty;

    public long UserId { get; set; }
}
