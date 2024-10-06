using AutoMapper;
using SecurityApp.Application.Features.Animal.Commands.CreateAnimal;
using SecurityApp.Application.Features.Animal.Commands.DeleteAnimal;
using SecurityApp.Application.Features.Animal.Commands.UpdateAnimal;
using SecurityApp.Application.Features.Animal.Queries;
using SecurityApp.Application.Features.Cuidado.Commands.CreateCuidado;
using SecurityApp.Application.Features.Cuidado.Queries;
using SecurityApp.Application.Features.Cuidador.Commands.CreateCuidador;
using SecurityApp.Application.Features.Cuidador.Commands.DeleteCuidador;
using SecurityApp.Application.Features.Cuidador.Commands.UpdateCuidador;
using SecurityApp.Domain.Common;

namespace SecurityApp.Application.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Animal, AnimalVm>();
            CreateMap<CreateAnimalCommand, Animal>();
            CreateMap<UpdateAnimalCommand, Animal>();
            CreateMap<DeleteAnimalCommand, Animal>();

            CreateMap<Cuidado, CuidadoVm>();
            CreateMap<CreateCuidadoCommand, Cuidado>();

            CreateMap<Cuidador, CuidadoVm>();
            CreateMap<CreateCuidadorCommand, Cuidado>();
            CreateMap<UpdateCuidadorCommand, Cuidado>();
            CreateMap<DeleteCuidadorCommand, Cuidado>();
        }
    }
}
