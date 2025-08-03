using MediatR;

namespace WorkoutPlanner.Application.Command.SetCommand;

public record DeleteSetCommand : IRequest<string>
{
    public int Id { get; set; }
}
