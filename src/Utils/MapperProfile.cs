using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using static src.DTO.AddressDTO;
using static src.DTO.UserDTO;
using static src.DTO.GemstoneCarvingsDTO;
using static src.DTO.GemstonesDTO;
using static src.DTO.JewelryDTO;

namespace src.Utils
{
    /// <summary>
    /// MapperProfile class is typically used to:
    /// mappings between entity classes and DTOs (Data Transfer Objects)
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapping configurations between entity classes and DTOs
            CreateMap<Users, UserReadDto>();
            CreateMap<UserCreateDto, Users>();

            // Mapping from UserUpdateDto to Users with a condition to map properties only if they are not null
            CreateMap<UserUpdateDto, Users>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Additional mappings
            CreateMap<UserLoginDto, Users>();
            CreateMap<PasswordUpdateDto, Users>();

            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressCreateDto, Address>();

            // Mapping from AddressUpdateDto to Address with a condition to map properties only if they are not null
            CreateMap<AddressUpdateDto, Address>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            //GemstonesCravings mappings
            //table name is "Gemstones_Carvings" 
            CreateMap<Gemstones_Carvings, GemstoneCarvingReadDto>();
            CreateMap<GemstoneCarvingCreateDto, Gemstones_Carvings>();
            // Creates a mapping from GemstoneCarvingUpdateDto to Gemstones_Carvings and applies a condition to map only non-null members
            CreateMap<GemstoneCarvingUpdateDto, Gemstones_Carvings>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Gemstones mappings
            CreateMap<Gemstones, GemstoneReadDto>();
            CreateMap<GemstoneCreateDto, Gemstones>();
            // Creates a mapping from GemstoneUpdateDto to Gemstones and applies a condition to map only non-null members
            CreateMap<GemstoneUpdateDto, Gemstones>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Jewelry mappings 
            CreateMap<Jewelry, JewelryReadDto>();
            CreateMap<JewelryCreateDto, Jewelry>();
            // Creates a mapping from JewelryUpdateDto to Jewelry and applies a condition to map only non-null members
            CreateMap<JewelryUpdateDto, Jewelry>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


        }
    }
}
