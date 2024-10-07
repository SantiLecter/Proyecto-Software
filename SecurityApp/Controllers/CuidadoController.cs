using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.Application.Features.Animal.Queries.GetAnimalById;
using SecurityApp.Application.Features.Animal.Queries;
using SecurityApp.Application.Features.Cuidado.Commands.CreateCuidado;
using System.Net;
using SecurityApp.Application.Features.Cuidado.Queries.GetCuidadoByIds;
using SecurityApp.Application.Features.Cuidado.Queries;

namespace SecurityApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CuidadoController : ControllerBase
{
    private IMediator _mediator;

    public CuidadoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{animalId}/{cuidadorId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    // [Authorize]
    public async Task<ActionResult<CuidadoVm>> GetCuidadoById(string animalId, string cuidadorId)
    {
        var query = new GetCuidadoByIdsQuery(animalId, cuidadorId);
        var cuidado = await _mediator.Send(query);
        return cuidado;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<string>> CreateCuidado([FromBody] CreateCuidadoCommand command)
    {
        var newAnimal = await _mediator.Send(command);
        return newAnimal;
    }
}