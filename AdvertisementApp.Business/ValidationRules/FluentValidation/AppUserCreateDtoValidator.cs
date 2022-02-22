using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(a => a.GenderId).NotEmpty();
            RuleFor(a => a.Firstname).NotEmpty();
            RuleFor(a => a.Surname).NotEmpty();
            RuleFor(a => a.UserName).NotEmpty();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.PhoneNumber).NotEmpty();
        }
    }
}
