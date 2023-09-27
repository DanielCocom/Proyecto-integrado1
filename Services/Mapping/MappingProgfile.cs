using AutoMapper;
using MyProject.Domain.Entities;
using MyProject.Domain.Dtos;


namespace MyProject.Services.Mapping
{
    public class MappingProfile : Profile{
         public MappingProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
        }
    }
    
}