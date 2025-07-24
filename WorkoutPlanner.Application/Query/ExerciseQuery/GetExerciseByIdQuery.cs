using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Query.ExerciseQuery;

public record GetExerciseByIdQuery : IRequest<ExerciseDto>
{
    public int Id { get; set; }
}
