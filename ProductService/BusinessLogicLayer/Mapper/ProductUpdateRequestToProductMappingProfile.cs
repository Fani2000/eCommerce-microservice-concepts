﻿using AutoMapper;
using ProductService.BusinessLogicLayer.DTO;
using ProductsService.DataAccessLayer.Entities;

namespace ProductService.BusinessLogicLayer.Mapper;

public class ProductUpdateRequestToProductMappingProfile : Profile
{
    public ProductUpdateRequestToProductMappingProfile()
    {
        CreateMap<ProductUpdateRequest, Product>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
            .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID))
            ;
    }
}