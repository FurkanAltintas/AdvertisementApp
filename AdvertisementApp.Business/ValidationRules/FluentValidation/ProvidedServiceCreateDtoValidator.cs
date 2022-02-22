using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class ProvidedServiceCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.ImagePath).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
        }
    }
}
