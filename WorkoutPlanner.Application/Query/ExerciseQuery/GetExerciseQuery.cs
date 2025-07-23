using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Query.ExerciseQuery;

public record GetExerciseQuery : IRequest<List<ExerciseDto>>
{
}
