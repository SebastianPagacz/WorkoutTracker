using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Application.Command.WorkoutCommand;
using WorkoutPlanner.Application.Query.WorkoutQuery;
using WorkoutTracker.Domain.Dto;

namespace WorkoutTracker.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(WorkoutDto data)
    {
        var result = await mediator.Send(new AddWorkoutCommand
        {
            Date = data.Date,
            Name = data.Name,
        });

        return StatusCode(200, result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetWorkoutsQuery());

        return StatusCode(200, result);
    }
}
