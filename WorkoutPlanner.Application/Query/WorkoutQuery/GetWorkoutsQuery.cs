using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Query.WorkoutQuery;

public record GetWorkoutsQuery : IRequest<List<WorkoutDto>> { }
