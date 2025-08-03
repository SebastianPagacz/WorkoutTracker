using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.WorkoutCommand;

public class PatchWorkoutHandler(IWorkoutRepository repository, IMapper mapper) : IRequestHandler<PatchWorkoutCommand, WorkoutDto>
{
    public async Task<WorkoutDto> Handle(PatchWorkoutCommand request, CancellationToken cancellationToken)
    {
        var existingWorkout = await repository.GetByIdAsync(request.Id);

        if (existingWorkout == null || existingWorkout.IsDeleted)
            throw new ItemNotFoundException($"Workout with Id {request.Id} was not found");

        if(!String.IsNullOrEmpty(request.Name))
            existingWorkout.Name = request.Name;

        if(request.Date != null)
            existingWorkout.Date = (DateOnly)request.Date;

        return mapper.Map<WorkoutDto>(existingWorkout);
    }
}
