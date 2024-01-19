using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {   
        public MappingProfiles()
        {
            //CreateMap<Product, ProductToReturnDto>(); crea in automatico il PDO da product a ProducToReturnoDto tramite applicativo automapper, va aggiunto al file Program.cs
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
        
    }
}