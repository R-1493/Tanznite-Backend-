using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Entity;
using static src.DTO.AddressDTO;
using static src.DTO.CartDTO;
using static src.DTO.CategoryDTO;
using static src.DTO.GemstonesDTO;
using static src.DTO.GemstoneShapeDTO;
using static src.DTO.JewelryDTO;
using static src.DTO.OrderDTO;
using static src.DTO.PaymentDTO;
using static src.DTO.ReviewDTO;
using static src.DTO.SingleProductDTO;
using static src.DTO.UserDTO;

namespace src.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Review, ReviewReadDTO>();
            CreateMap<ReviewCreateDTO, Review>();
            CreateMap<ReviewUpdateDTO, Review>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Cart, CartReadDTO>();
            CreateMap<CartCreateDTO, Cart>();
            CreateMap<CartUpdateDTO, Cart>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Users, UserReadDto>();
            CreateMap<UserCreateDto, Users>();
            CreateMap<UserLoginDto, Users>();
            CreateMap<PasswordUpdateDto, Users>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AdminUpdateDto, Users>();
            CreateMap<Users, UserProfileDto>();

            CreateMap<Address, AddressReadDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString())); // Con
            CreateMap<AddressCreateDto, Address>();
            CreateMap<AddressUpdateDto, Address>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>()
                .ForAllMembers(options =>
                    options.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Gemstones, GemstoneReadDto>();
            CreateMap<GemstoneCreateDto, Gemstones>();
            CreateMap<GemstoneUpdateDto, Gemstones>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Jewelry, JewelryDTO.JewelryReadDto>();
            CreateMap<JewelryCreateDto, Jewelry>();
            CreateMap<JewelryUpdateDto, Jewelry>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SingleProduct, SingleProductReadDto>();
            CreateMap<SingleProductCreateDto, SingleProduct>();
            CreateMap<SingleProductUpdateDto, SingleProduct>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<GemstoneShape, GemstoneShapeReadDTO>();
            CreateMap<GemstoneShapeCreateDTO, GemstoneShape>();
        }
    } // end class
} // end namespace
