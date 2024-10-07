using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.Application.Features.Vacuna.Commands.CreateVacuna;
using System.Net;
using SecurityApp.Application.Features.Vacuna.Queries;
using SecurityApp.Application.Features.Vacuna.Queries.GetVacunaByAnimal;

namespace SecurityApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VacunaController : ControllerBase
{
    private IMediator _mediator;

    public VacunaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<VacunaVm>> GetVacunaByAnimalID(string id)
    {
        var query = new GetVacunaByAnimalQuery(id);
        var vacuna = await _mediator.Send(query);
        return vacuna;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<string>> CreateVacuna([FromBody] CreateVacunaCommand command)
    {
        var newVacuna = await _mediator.Send(command);
        return newVacuna;
    }
}
