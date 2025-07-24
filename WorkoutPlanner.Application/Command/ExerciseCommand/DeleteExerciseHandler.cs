using MediatR;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.ExerciseCommand;

public class DeleteExerciseHandler(IExerciseRepository repository) : IRequestHandler<DeleteExerciseCommand, string>
{
    async Task<string> IRequestHandler<DeleteExerciseCommand, string>.Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
    {
        var exisitngExercise = await repository.GetByIdAsync(request.Id);

        if (exisitngExercise == null || exisitngExercise.IsDeleted)
            throw new ItemNotFoundException($"Exercise {request.Id} was not found");

        exisitngExercise.IsDeleted = true;
        
        await repository.UpdateAsync();

        return $"Deleted exercise {request.Id}";
    }
}
