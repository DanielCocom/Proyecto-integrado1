using AutoMapper;
using MyProject.Domain.Entities;
using MyProject.Domain.Dtos;


namespace MyProject.Services.Mapping
{
    public class CarritoMappingProfile : Profile{
         public CarritoMappingProfile()
        {
            CreateMap<Carrito, CarritoDto>();
            CreateMap<CarritoDto, Carrito>();
        }
    }
    
}