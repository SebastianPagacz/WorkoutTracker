namespace WorkoutTracker.Domain.Dto;

public class SetDto
{
    public string Name { get; set; } = string.Empty;
    public int Repetitions { get; set; }
    public decimal Weigth { get; set; }
}
