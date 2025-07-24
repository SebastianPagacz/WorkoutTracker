using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Enums;

namespace WorkoutPlanner.Application.Command.ExerciseCommand;

public record PatchExerciseCommand : IRequest<ExerciseDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public BodyPartEnum? BodyPart { get; set; }
}
