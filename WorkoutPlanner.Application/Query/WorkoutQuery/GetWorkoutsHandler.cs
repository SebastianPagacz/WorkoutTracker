using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Query.WorkoutQuery
{
    public class GetWorkoutsHandler(IWorkoutRepository repository, IMapper mapper) : IRequestHandler<GetWorkoutsQuery, List<WorkoutDto>>
    {
        public async Task<List<WorkoutDto>> Handle(GetWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var existingWorkouts = await repository.GetAsync();
            var filteredResults = existingWorkouts.Where(w => !w.IsDeleted);

            return mapper.Map<List<WorkoutDto>>(filteredResults);
        }
    }
}
