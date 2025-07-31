namespace WorkoutTracker.Domain.Dto;

public class WorkoutDto
{
    public DateOnly Date { get; set; }
    public string Name { get; set; } = string.Empty;
}
