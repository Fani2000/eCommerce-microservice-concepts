﻿using FluentValidation;
using ProductService.BusinessLogicLayer.DTO;

namespace ProductsService.DataAccessLayer.Validators;

public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
        //ProductName
        RuleFor(temp => temp.ProductName)
            .NotEmpty().WithMessage("Product Name can't be blank");

        //Category
        RuleFor(temp => temp.Category)
            .IsInEnum().WithMessage("Product Name can't be blank");

        //UnitPrice
        RuleFor(temp => temp.UnitPrice)
            .InclusiveBetween(0, double.MaxValue).WithMessage($"Unit Price should between 0 to {double.MaxValue}");

        //QuantityInStock
        RuleFor(temp => temp.QuantityInStock)
            .InclusiveBetween(0, int.MaxValue).WithMessage($"Quantity in Stock should between 0 to {int.MaxValue}");
    }
}