using AutoMapper;
using MediatR;
using SecurityApp.Application.Contracts.Persistence;

namespace SecurityApp.Application.Features.Cuidador.Commands.UpdateCuidador;

public class UpdateCuidadorCommandHandler : IRequestHandler<UpdateCuidadorCommand>
{
    private readonly ICuidadorRepository _cuidadorRepository;
    private readonly IMapper _mapper;

    public UpdateCuidadorCommandHandler(ICuidadorRepository cuidadorRepository, IMapper mapper)
    {
        _cuidadorRepository = cuidadorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCuidadorCommand request, CancellationToken cancellationToken)
    {
        var cuidadorToUpdate = await _cuidadorRepository.GetByIdAsync(request.Id);

        if (cuidadorToUpdate == null)
        {
            throw (new Exception($"{{nameof(request.Id)}} {{request.Id}} does not exists"));
        }
        
        _mapper.Map(request, cuidadorToUpdate, typeof(UpdateCuidadorCommand), typeof(Domain.Common.Cuidador));
        await _cuidadorRepository.UpdateAsync(cuidadorToUpdate);
        return Unit.Value;
    }
}