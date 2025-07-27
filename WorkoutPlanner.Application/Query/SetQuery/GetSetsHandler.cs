using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.SetQuery;

public class GetSetsHandler(ISetRepository repository, IMapper mapper) : IRequestHandler<GetSetsCommand, List<SetDto>>
{
    public async Task<List<SetDto>> Handle(GetSetsCommand request, CancellationToken cancellationToken)
    {
        var sets = await repository.GetAsync();

        return mapper.Map<List<SetDto>>(sets);
    }
}
