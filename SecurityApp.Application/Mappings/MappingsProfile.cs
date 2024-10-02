using AutoMapper;
using SecurityApp.Application.Features.Animal.Commands.CreateAnimal;
using SecurityApp.Application.Features.Animal.Commands.DeleteAnimal;
using SecurityApp.Application.Features.Animal.Commands.UpdateAnimal;
using SecurityApp.Application.Features.Animal.Queries;
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
        }
    }
}
