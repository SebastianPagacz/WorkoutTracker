using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Enums;

namespace WorkoutPlanner.Application.Command.ExerciseCommand;

public record AddExerciseCommand : IRequest<ExerciseDto>
{
    public string Name { get; set; } = string.Empty;
    public BodyPartEnum BodyPart { get; set; }
}
