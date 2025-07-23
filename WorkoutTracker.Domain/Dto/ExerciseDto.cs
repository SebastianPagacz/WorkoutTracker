using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Domain.Dto;

public class ExerciseDto
{
    public string Name { get; set; } = string.Empty;

    public BodyPartEnum BodyPart { get; set; }
}
