using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Query.SetQuery;

public record GetSetsCommand : IRequest<List<SetDto>> { }
