using MediatR;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.SetCommand;

public class DeleteSetHandler(ISetRepository repository) : IRequestHandler<DeleteSetCommand, string>
{
    public async Task<string> Handle(DeleteSetCommand request, CancellationToken cancellationToken)
    {
        var existingSet = await repository.GetByIdAsync(request.Id);

        if (existingSet == null || existingSet.IsDeleted)
            throw new ItemNotFoundException($"Set with id {request.Id} was not found");

        existingSet.IsDeleted = true;
        await repository.UpdateAsync(existingSet);

        return $"Set with id {request.Id} was deleted";
    }
}
