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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetWorkoutByIdQuery { Id = id });

        return StatusCode(200, result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, WorkoutDto data)
    {
        var result = await mediator.Send(new PatchWorkoutCommand
        {
            Id = id,
            Name = data.Name,
            Date = data.Date,
        });

        return StatusCode(200, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteWorkoutCommand { Id = id });

        return StatusCode(200, result);
    }
}
