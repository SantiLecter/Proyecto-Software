using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.Application.Features.Cuidador.Commands.CreateCuidador;
using SecurityApp.Application.Features.Cuidador.Commands.UpdateCuidador;
using SecurityApp.Application.Features.Cuidador.Commands.DeleteCuidador;
using SecurityApp.Application.Features.Cuidador.Queries.GetListCuidadores;
using SecurityApp.Application.Features.Cuidador.Queries.GetCuidadorById;
using System.Net;
using SecurityApp.Application.Features.Cuidador.Queries;

namespace SecurityApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CuidadorController : ControllerBase
{
    private IMediator _mediator;

    public CuidadorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<IEnumerable<CuidadorVm>>> GetAllCuidadores()
    {
        var query = new GetListCuidadoresQuery();
        var list = await _mediator.Send(query);
        return Ok(list);
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<CuidadorVm>> GetCuidadorByID(string id)
    {
        var query = new GetCuidadorByIdQuery(id);
        var cuidador = await _mediator.Send(query);
        return cuidador;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<string>> CreateCuidador([FromBody] CreateCuidadorCommand command)
    {
        var newCuidador = await _mediator.Send(command);
        return newCuidador;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    //[Authorize]
    public async Task<ActionResult> UpdateCuidador(string id, [FromBody] UpdateCuidadorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("El ID especificado en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    //[Authorize]
    public async Task<ActionResult> DeleteCuidador(string id, [FromBody] DeleteCuidadorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("El ID especificado en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        await _mediator.Send(command);
        return NoContent();
    }
}
