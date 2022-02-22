using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola boş olamaz");
        }
    }
}
