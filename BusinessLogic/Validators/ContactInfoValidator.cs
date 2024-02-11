//using BusinessLogic.DTOs;
//using BusinessLogic.Extensions;
//using DataAccess.Data.Entities;
//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLogic.Validators
//{
//    internal class ContactInfoValidator : AbstractValidator<ContactInfoDto>
//    {
//        public ContactInfoValidator() 
//        {
//            RuleFor(x => x.PhoneNumber)
//                .NotEmpty()
//                .MinimumLength(10)
//                .Matches("^\\+(\\d{1,4})?[-.\\s]?\\(?\\d{1,4}\\)?[-.\\s]?\\d{1,9}$").WithMessage("{PropertyName} incorrect format");

//            RuleFor(x => x.PhoneNumber)
//                .MinimumLength(10)
//                .Matches("^\\+(\\d{1,4})?[-.\\s]?\\(?\\d{1,4}\\)?[-.\\s]?\\d{1,9}$").WithMessage("{PropertyName} incorrect format");

//            RuleFor(x => x.WebSiteUrl)
//                .Must(ValidatorsExtensions.LinkMustBeAUri).WithMessage("{PropertyName} must be a valid URL address.");

//            RuleFor(x => x.CityId)
//                .NotEmpty();

//            RuleFor(x => x.UserId)
//                .NotEmpty();
//        }
//    }
//}
