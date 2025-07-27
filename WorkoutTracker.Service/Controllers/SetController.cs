using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WorkoutPlanner.Application.Command.SetCommand;
using WorkoutPlanner.Application.Query.SetQuery;
using WorkoutTracker.Domain.Dto;

namespace WorkoutTracker.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SetController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(SetDto set, int exerciseId, int workoutId)
    {
        var result = await mediator.Send(new AddSetCommand
        {
            Name = set.Name,
            Repetitions = set.Repetitions,
            Weigth = set.Weigth,
            ExerciseId = exerciseId,
            WorkoutId = workoutId
        });

        return StatusCode(200, result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetSetsCommand());

        return StatusCode(200, result);
    }
}
