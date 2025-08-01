using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Command.WorkoutCommand;

public record AddWorkoutCommand : IRequest<WorkoutDto>
{
    public DateOnly Date {  get; set; }
    public string Name { get; set; } = string.Empty;
}
