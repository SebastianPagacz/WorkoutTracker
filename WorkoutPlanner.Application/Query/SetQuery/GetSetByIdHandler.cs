using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.SetQuery;

public class GetSetByIdHandler(ISetRepository repository, IMapper mapper) : IRequestHandler<GetSetByIdQuery, SetDto>
{
    public async Task<SetDto> Handle(GetSetByIdQuery request, CancellationToken cancellationToken)
    {
        var exisitngSet = await repository.GetByIdAsync(request.Id);

        if (exisitngSet == null || exisitngSet.IsDeleted)
            throw new ItemNotFoundException($"Set with id {request.Id} was not found");

        return mapper.Map<SetDto>(exisitngSet);
    }
}
