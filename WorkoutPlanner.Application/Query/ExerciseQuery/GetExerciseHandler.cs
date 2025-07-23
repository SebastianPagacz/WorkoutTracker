using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.ExerciseQuery;

public class GetExerciseHandler(IExerciseRepository repository, IMapper mapper) : IRequestHandler<GetExerciseQuery, List<ExerciseDto>>
{
    public async Task<List<ExerciseDto>> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        var exercisesList = await repository.GetAsync();

        var filteredList = exercisesList.Where(e => !e.IsDeleted).ToList();

        return mapper.Map<List<ExerciseDto>>(filteredList);
    }
}
