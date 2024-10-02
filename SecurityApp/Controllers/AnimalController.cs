using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.Application.Features.Animal.Commands.CreateAnimal;
using SecurityApp.Application.Features.Animal.Commands.DeleteAnimal;
using SecurityApp.Application.Features.Animal.Commands.UpdateAnimal;
using SecurityApp.Application.Features.Animal.Queries;
using SecurityApp.Application.Features.Animal.Queries.GetAnimalById;
using SecurityApp.Application.Features.Animal.Queries.GetAnimalsList;

namespace SecurityApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class AnimalController : ControllerBase
{
    private IMediator _mediator;

    public AnimalController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize]
    public async Task<ActionResult<IEnumerable<AnimalVm>>> GetAllAnimals()
    {
        var query = new GetAnimalsListQuery();
        var list = await _mediator.Send(query);
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize]
    public async Task<ActionResult<AnimalVm>> GetAnimalById(string id)
    {
        var query = new GetAnimalByIdQuery(id);
        var animal = await _mediator.Send(query);
        return animal;
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize]
    public async Task<ActionResult<string>> CreateAnimal([FromBody] CreateAnimalCommand command)
    {
        var newAnimal = await _mediator.Send(command);
        return newAnimal;
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize]
    public async Task<ActionResult> UpdateAnimal([FromBody] UpdateAnimalCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize]
    public async Task<ActionResult<bool>> DeleteAnimal(DeleteAnimalCommand command)
    {
        var deleteAnimal = await _mediator.Send(command);
        return deleteAnimal;
    }
    
}