using MediatR;

namespace SecurityApp.Application.Features.Animal.Commands.UpdateAnimal;

public class UpdateAnimalCommand : IRequest
{
    public string Id { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string TipoComida { get; set; } = string.Empty;
    public string EstadoSalud { get; set; } = string.Empty;
    public float Peso { get; set; }
}