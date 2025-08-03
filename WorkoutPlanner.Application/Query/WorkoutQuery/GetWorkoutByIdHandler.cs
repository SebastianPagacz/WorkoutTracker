using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.WorkoutQuery;

public class GetWorkoutByIdHandler(IWorkoutRepository repository, IMapper mapper) : IRequestHandler<GetWorkoutByIdQuery, WorkoutDto>
{
    public async Task<WorkoutDto> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
    {
        var existingWorkout = await repository.GetByIdAsync(request.Id);

        if (existingWorkout is null || existingWorkout.IsDeleted)
            throw new ItemNotFoundException($"Workout with Id {request.Id} does not exist");

        return mapper.Map<WorkoutDto>(existingWorkout);
    }
}
