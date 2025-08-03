using MediatR;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.WorkoutCommand;

public class DeleteWorkoutHandler(IWorkoutRepository repository) : IRequestHandler<DeleteWorkoutCommand, string>
{
    public async Task<string> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
    {
        var existingWorkout = await repository.GetByIdAsync(request.Id);

        if (existingWorkout == null || existingWorkout.IsDeleted)
            throw new ItemNotFoundException($"Workout with Id {request.Id} was not found");

        existingWorkout.IsDeleted = true;
        await repository.UpdateAsync(existingWorkout);
        
        return $"Workout with Id {request.Id} was delted";
    }
}
