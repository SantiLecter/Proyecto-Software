using MediatR;

namespace SecurityApp.Application.Features.Animal.Commands.CreateAnimal;

public class CreateAnimalCommand : IRequest<string>
{
    public string Especie { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string TipoComida { get; set; } = string.Empty;
    public string EstadoSalud { get; set; } = string.Empty;
    public float Peso { get; set; }
}