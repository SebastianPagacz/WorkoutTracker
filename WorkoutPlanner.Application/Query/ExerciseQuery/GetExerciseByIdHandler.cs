using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.ExerciseQuery;

public class GetExerciseByIdHandler(IExerciseRepository repository, IMapper mapper) : IRequestHandler<GetExerciseByIdQuery, ExerciseDto>
{
    public async Task<ExerciseDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetByIdAsync(request.Id);

        if (response is null || response.IsDeleted)
            throw new ItemNotFoundException($"Exercise {request.Id} was not found");

        return mapper.Map<ExerciseDto>(response);
    }
}
