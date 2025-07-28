using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.SetCommand;

public class PatchSetHandler(ISetRepository repository, IMapper mapper) : IRequestHandler<PatchSetCommand, SetDto>
{
    public async Task<SetDto> Handle(PatchSetCommand request, CancellationToken cancellationToken)
    {
        var exisitngSet = await repository.GetByIdAsync(request.Id);

        if (exisitngSet == null || exisitngSet.IsDeleted)
            throw new ItemNotFoundException($"Set with id {request.Id} was not found");

        if (request.Repetitions != null)
            exisitngSet.Repetitions = (int)request.Repetitions;

        if (request.Weigth != null)
            exisitngSet.Weigth = (decimal)request.Weigth;

        await repository.UpdateAsync(exisitngSet);

        return mapper.Map<SetDto>(exisitngSet);
    }
}
