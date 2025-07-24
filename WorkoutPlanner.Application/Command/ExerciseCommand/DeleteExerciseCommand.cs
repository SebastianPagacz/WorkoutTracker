using MediatR;

namespace WorkoutPlanner.Application.Command.ExerciseCommand;

public record DeleteExerciseCommand : IRequest<string>
{
    public int Id { get; set; }
}
