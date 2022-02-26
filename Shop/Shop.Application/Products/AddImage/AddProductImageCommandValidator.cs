﻿using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommandValidator:AbstractValidator<AddProductImageCommand>
    {
        public AddProductImageCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();

            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(0).WithMessage("ترتیب باید بیشتر از -1 باشد!");
        }
    }
}