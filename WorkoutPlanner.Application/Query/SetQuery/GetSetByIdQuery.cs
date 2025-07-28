using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Query.SetQuery;

public record GetSetByIdQuery : IRequest<SetDto>
{
    public int Id { get; set; }
}
