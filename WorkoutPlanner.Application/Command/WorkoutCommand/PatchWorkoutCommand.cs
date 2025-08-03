using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Command.WorkoutCommand;

public record PatchWorkoutCommand : IRequest<WorkoutDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly? Date { get; set; }
}
