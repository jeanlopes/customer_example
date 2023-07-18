using AutoMapper;
using CustomerExample.Application.DTOs;
using CustomerExample.Domain.Entities;
using CustomerExample.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace CustomerExample.Application.Mapping
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile() {


            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.LogoPath, opt => opt.MapFrom(src => FileHelper.SaveLogoAndGetPath(src.Logo)))
                .ReverseMap()
                .ForMember(dest => dest.Streets, opt => opt.MapFrom(src =>
                    !src.Addresses.Any() ?
                        new List<StreetDTO>() :
                    src.Addresses.Select(a => new StreetDTO { Street = a.Street})
                ));

            CreateMap<CustomerEditDTO, CustomerDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
