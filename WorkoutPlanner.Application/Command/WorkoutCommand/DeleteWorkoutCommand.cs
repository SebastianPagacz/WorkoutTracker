using MediatR;

namespace WorkoutPlanner.Application.Command.WorkoutCommand;

public record DeleteWorkoutCommand : IRequest<string>
{
    public int Id { get; set; }
}
