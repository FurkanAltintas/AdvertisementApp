using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(a => a.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(a => a.AdvertisementId).NotEmpty();
            RuleFor(a => a.AppUserId).NotEmpty();
            RuleFor(a => a.CvPath).NotEmpty().WithMessage("Bir cv dosyası seçiniz.");
            RuleFor(a => a.WorkExperience).InclusiveBetween(0, int.MaxValue).WithMessage("Değer aralığı 0'dan aşağı olamaz");
            RuleFor(a => a.EndDate).NotEmpty().When(a => a.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Tecil tarihi boş bırakılamaz");
            // Null olamaz ne zaman MilitaryStatusId değeri Tecilliye eşit iken boş olamaz

            // WorkExperience int olduğu için default hali 0 geliyor. Kullanıcının deneyimi olmadığı için orası 0 geleceği için hata vermeyecektir. Bu yüzden deneyim kısmını değer aralığı olarak ayarlamamız gerekmektedir
        }
    }
}
