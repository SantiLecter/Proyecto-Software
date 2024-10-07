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
using SecurityApp.Application.Features.Cuidador.Queries;
using SecurityApp.Application.Features.Cuidador.Queries.GetListCuidadores;
using SecurityApp.Application.Features.Examen.Commands.CreateExamen;
using SecurityApp.Application.Features.Examen.Commands.DeleteExamen;
using SecurityApp.Application.Features.Examen.Commands.UpdateExamen;
using SecurityApp.Application.Features.Examen.Queries;
using SecurityApp.Application.Features.Vacuna.Commands.CreateVacuna;
using SecurityApp.Application.Features.Vacuna.Queries;
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

            CreateMap<Cuidador, CuidadorVm>();
            CreateMap<CreateCuidadorCommand, Cuidador>();
            CreateMap<UpdateCuidadorCommand, Cuidador>();
            CreateMap<DeleteCuidadorCommand, Cuidador>();

            CreateMap<Examen, ExamenVm>();
            CreateMap<CreateExamenCommand, Examen>();
            CreateMap<UpdateExamenCommand, Examen>();
            CreateMap<DeleteExamenCommand, Examen>();

            CreateMap<Vacuna, VacunaVm>();
            CreateMap<CreateVacunaCommand, Vacuna>();
        }
    }
}
