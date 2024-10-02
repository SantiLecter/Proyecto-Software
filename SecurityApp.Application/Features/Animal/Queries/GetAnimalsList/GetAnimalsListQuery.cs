using MediatR;

namespace SecurityApp.Application.Features.Animal.Queries.GetAnimalsList;

public class GetAnimalsListQuery : IRequest<List<AnimalVm>>
{
}