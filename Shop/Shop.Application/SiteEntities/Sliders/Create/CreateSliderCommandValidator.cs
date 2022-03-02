﻿using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator:AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Link)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.ImageFile)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }
}