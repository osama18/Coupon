using AutoMapper;
using System.Linq;
using Vouchers.Business.Models;
using Vouchers.DAL.Entities;

namespace Vouchers.Business.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Voucher, VoucherDTO>()
                .ForMember(c => c.Id, act => act.MapFrom(src => src.ExternalId))
                .ForMember(c => c.Name, act => act.MapFrom(src => src.Deal.Name))
                .ForMember(c => c.Price, act => act.MapFrom(src => src.Deal.Price))
                .ForMember(c => c.Products, act => act.MapFrom(src => src.Deal.Products));

            CreateMap<Product, ProductDTO>();
        }
    }
}