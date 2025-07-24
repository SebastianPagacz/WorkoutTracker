using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.ExerciseQuery;

public class GetExerciseByIdHandler(IExerciseRepository repository, IMapper mapper) : IRequestHandler<GetExerciseByIdQuery, ExerciseDto>
{
    public async Task<ExerciseDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetByIdAsync(request.Id);

        if (response is null || response.IsDeleted)
            throw new Exception("TODO: add custom exception");

        return mapper.Map<ExerciseDto>(response);
    }
}
