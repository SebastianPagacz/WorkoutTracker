using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Query.WorkoutQuery;

public record GetWorkoutByIdQuery : IRequest<WorkoutDto>
{
    public int Id { get; set; }
}
