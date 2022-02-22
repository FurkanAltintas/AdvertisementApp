using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.GenderId).NotEmpty();
            RuleFor(a => a.Firstname).NotEmpty();
            RuleFor(a => a.Surname).NotEmpty();
            RuleFor(a => a.UserName).NotEmpty();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.PhoneNumber).NotEmpty();
        }
    }
}
