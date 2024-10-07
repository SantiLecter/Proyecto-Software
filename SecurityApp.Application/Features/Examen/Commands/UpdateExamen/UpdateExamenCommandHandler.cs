using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Examen.Commands.UpdateExamen;

public class UpdateExamenCommandHandler : IRequestHandler<UpdateExamenCommand>
{
    private readonly IExamenRepository _examenRepository;
    private readonly IMapper _mapper;

    public UpdateExamenCommandHandler(IExamenRepository examenRepository, IMapper mapper)
    {
        _examenRepository = examenRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateExamenCommand request, CancellationToken cancellationToken)
    {
        var examenToUpdate = await _examenRepository.GetByIdAsync(request.Id);
        if (examenToUpdate == null)
        {
            throw (new Exception($"{{nameof(request.Id)}} {{request.Id}} does not exists"));
        }
        _mapper.Map(request, examenToUpdate, typeof(UpdateExamenCommand), typeof(Domain.Common.Examen));
        await _examenRepository.UpdateAsync(examenToUpdate);
        return Unit.Value;
    }
}