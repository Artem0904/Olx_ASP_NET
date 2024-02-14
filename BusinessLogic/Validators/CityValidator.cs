using BusinessLogic.DTOs;
using DataAccess.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators 
{
    internal class CityValidator : AbstractValidator<CityDto>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            //RuleFor(x => x.CountryId)
            //    .NotEmpty();
        }
    }
}
